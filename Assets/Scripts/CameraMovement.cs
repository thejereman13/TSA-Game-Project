using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject target;
	Vector3 positionOffset = Vector3.one;
	CharacterMovement characterMovement;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Character");
		characterMovement = GameObject.Find ("Character").GetComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("SkyCar");
		//PlayerMovement playerMovement = player.GetComponent<PlayerMovement> ();
		if (target != null) 
		{
			transform.LookAt (target.transform);
		}
		//transform.position = target.transform.position + new Vector3 (0, 2, -4);
		if (characterMovement.turn != 0) {
			transform.RotateAround (target.transform.position, Vector3.up, characterMovement.turn / 360 * Settings.mouseSensitivity);
		}
		
	}
}
