using UnityEngine;
using System.Collections;

public class DevOptions : MonoBehaviour {
	public static bool noclip;
	public static bool fly;
	public static bool debug;

	public void SetNoClip(bool bul){
		noclip = bul;
	}
	public void SetFly(bool bul){
		fly = bul;
	}
	public void SetDebug(bool bul){
		debug = bul;
	}
}
