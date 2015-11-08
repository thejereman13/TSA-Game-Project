using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float turn;
	public Rigidbody rb;
	public Collider col;
	private float speedMultiplier = 1;
	private float maxSpeed = 10f;
	public bool isGrounded;
	private float jumpHeight = 40000;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		float side = Input.GetAxis ("Horizontal");
		float front = Input.GetAxis ("Vertical");
		if ((front > 0 || front < 0) && Mathf.Abs (rb.velocity.z) < maxSpeed) {
			rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + front) * speedMultiplier;
		} else {
			if (Mathf.Floor(rb.velocity.z) != 0){
				rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z / 2);
			}
		}
		if ((side < 0 || side > 0) && Mathf.Abs(rb.velocity.x) < maxSpeed) {
			rb.velocity = new Vector3(rb.velocity.x + side, rb.velocity.y, rb.velocity.z) * speedMultiplier;
		}else {
			if (Mathf.Floor(rb.velocity.x) != 0){
				rb.velocity = new Vector3(rb.velocity.x / 2, rb.velocity.y, rb.velocity.z);
			}
		}
		if (Input.GetButton ("Jump") && isGrounded) {
			rb.AddForce(Vector3.up * jumpHeight);
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isGrounded = true;
		}
	}
}
