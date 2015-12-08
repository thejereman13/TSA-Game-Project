using UnityEngine;
using System.Collections;

public class IntVariable : MonoBehaviour, VarBase {
	public int pubVar;
	// Use this for initialization
	void Start () {
	
	}

	public int GetIntVar(){
		return pubVar;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
