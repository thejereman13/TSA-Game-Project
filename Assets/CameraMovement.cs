using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject target;
	Vector3 positionOffset = Vector3.one;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("SkyCar");
		//PlayerMovement playerMovement = player.GetComponent<PlayerMovement> ();
		if (target != null) 
		{
			//transform.LookAt (target.transform);
		}
		transform.position = target.transform.position + new Vector3 (0, 2, -4);
		/*if (playerMovement.turn != 0) {
			transform.Rotate (0, playerMovement.turn, 0);
		}*/
		
	}
}
