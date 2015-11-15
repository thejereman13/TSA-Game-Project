using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject target;
	Vector3 positionOffset = Vector3.one;
	CharacterMovement characterMovement;
	float tempY = 0;
	void Start () {
		target = GameObject.Find("Character");
		characterMovement = GameObject.Find ("Character").GetComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("SkyCar");
		if (target != null) 
		{
			transform.LookAt (target.transform);
		}
		if (characterMovement.turn != 0) {
			transform.RotateAround (target.transform.position, Vector3.up, characterMovement.turn / 360 * Settings.mouseSensitivity);
		}
		if (target.transform.position.y > 1) {
			transform.position = new Vector3 (transform.position.x, Mathf.SmoothStep(target.transform.position.y + 2f, target.transform.position.y + 2f + target.transform.position.y / 5, .5f), transform.position.z);
		}
	}
}
