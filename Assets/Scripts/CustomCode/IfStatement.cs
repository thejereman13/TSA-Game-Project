using UnityEngine;
using System.Collections;

public class IfStatement : MonoBehaviour, CodeBase{
	public string input1, input2;
	public string output;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Execute(){
		GameObject obj1 = GameObject.Find (input1);
		GameObject obj2 = GameObject.Find (input2);
		if (obj1 != null && obj2 != null && obj1.GetComponent<VarBase>() != null && obj2.GetComponent<VarBase>() != null) {
			if (obj1.GetComponent<VarBase>().GetIntVar() == obj2.GetComponent<VarBase>().GetIntVar()){
				GameObject obj = GameObject.Find (output);
				if (obj != null) {
					obj.GetComponent<CodeBase>().Execute();
				}
			}
		}
	}
}
