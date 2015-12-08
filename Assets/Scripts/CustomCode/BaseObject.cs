using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour, CodeBase {
	public string output;
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find (output);
		if (obj != null) {
			obj.GetComponent<CodeBase>().Execute();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Execute(){

	}
}
