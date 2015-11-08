using UnityEngine;
using System.Collections;

public class CharacterJumpCollider : MonoBehaviour {
	CharacterMovement charMove;
	// Use this for initialization
	void Start () {
		charMove = GameObject.Find ("Character").GetComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		Debug.Log("Poop1");
		charMove.isGrounded = true;
	}
}
