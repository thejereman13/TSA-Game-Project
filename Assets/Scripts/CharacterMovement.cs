using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float turn;
	public Rigidbody rigidbody;
	public Collider col;
	public bool isGrounded;
	private float jumpHeight = 1.0f;
	public float speed = 10f;
	public float maxVelocityChange = 10.0f;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		col = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		turn = Input.GetAxis ("Mouse X");
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;
		
		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		rigidbody.AddForce( (isGrounded) ? (velocityChange):(velocityChange / 10), ForceMode.VelocityChange);

		if (Input.GetButton ("Jump") && isGrounded) {
			rigidbody.velocity = new Vector3 (velocity.x, Mathf.Sqrt(2 * jumpHeight * 9.81f), velocity.z);
			isGrounded = false;
		}

		if (turn != 0){
			transform.Rotate(0, turn * Settings.mouseSensitivity, 0);
		}
		rigidbody.AddForce (new Vector3 (0f, -9.81f * rigidbody.mass, 0f));
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = true;
		}
	}
}
