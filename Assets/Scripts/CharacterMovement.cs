using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float turn, look;
	public Rigidbody rigidbody;
	public Collider col;
	public bool isGrounded;
	private float jumpHeight = 800.0f;
	public float speed = 10f;
	public float maxVelocityChange = 8.0f;
	public int jumpTimer = 80;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		col = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		turn = Input.GetAxis ("Mouse X");
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, Input.GetAxis("Vertical") * speed);
		targetVelocity = transform.TransformDirection(targetVelocity);
		rigidbody.velocity = targetVelocity;
		if ((Mathf.Floor (rigidbody.velocity.x) != 0 || Mathf.Floor (rigidbody.velocity.z) != 0) && isGrounded == false) {
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x / 2, rigidbody.velocity.y, rigidbody.velocity.z / 2);
			rigidbody.AddForce (-targetVelocity / 4);
		}

		if (Input.GetButton ("Jump") && isGrounded && jumpTimer == 80) {
			rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			jumpTimer = 0;
		}

		if (turn != 0){
			transform.Rotate(0, turn * Settings.mouseSensitivity, 0);
		}
		if (jumpTimer != 80) {
			jumpTimer= jumpTimer + 2;
		}

		rigidbody.AddForce (new Vector3 (0f, -9.81f * rigidbody.mass, 0f));
		isGrounded = false;
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = true;
		}
	}
}
