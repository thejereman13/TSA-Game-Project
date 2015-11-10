using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float turn;
	public Rigidbody rigidbody;
	public Collider col;
	public bool isGrounded;
	private float jumpHeight = 20000.0f;
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
		//Add code to reduce velocity (divide by two with mathf.floor stuff)

		if (Input.GetButton ("Jump") && isGrounded && jumpTimer == 80) {
			rigidbody.AddForce(Vector3.up * 2 * jumpHeight);
			isGrounded = false;
			jumpTimer = 0;
		}

		if (turn != 0){
			transform.Rotate(0, turn * Settings.mouseSensitivity, 0);
		}
		if (jumpTimer != 80) {
			jumpTimer= jumpTimer + 2;
		}
		//rigidbody.AddForce (new Vector3 (0f, -9.81f * rigidbody.mass, 0f));
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = true;
		}
	}
}
