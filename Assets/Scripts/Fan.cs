using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit = new RaycastHit ();
		var layerMask = 1 << 8;
		Vector3 up = transform.TransformDirection (Vector3.up);
		if (Physics.SphereCast (transform.position - new Vector3(0, 1.1f, 0), 1f, up, out hit, 6f, LayerMask.GetMask("Character"))) {
			if (true){
				Debug.Log(hit.rigidbody.name);
			}
			if (hit.rigidbody.velocity.y < -0.5f){
				hit.rigidbody.AddForce(new Vector3(0, 0.5f, 0), ForceMode.VelocityChange);
			}else{
				hit.rigidbody.AddForce(new Vector3(0, .4f, 0), ForceMode.VelocityChange);
			}
		}
	}
}
