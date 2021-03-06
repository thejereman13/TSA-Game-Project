﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Transform window;
	static Transform newWindow;
	public static string currentWindowName;

	public Transform mainMenu;
	public Transform optionsMenu;
	public Transform newGame;
	public Transform pauseMenu;

	public static bool windowOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OpenWindow(string name){
		windowOpen = true;
		currentWindowName = name;
		switch (name) {
		case "MainMenu":
			newWindow = Instantiate(mainMenu);
			newWindow.SetParent(window, false);
			break;
		case "OptionsMenu":
			newWindow = Instantiate(optionsMenu);
			newWindow.SetParent(window, false);
			break;
		case "newGame":
			newWindow = Instantiate(newGame);
			newWindow.SetParent(window, false);
			break;
		case "PauseMenu":
			newWindow = Instantiate(pauseMenu);
			newWindow.SetParent(window, false);
			break;
		}
	}
	public void CloseWindow(){
		windowOpen = false;
		if (currentWindowName != null) {
			Destroy (GameObject.Find (currentWindowName + "(Clone)"));
		}
	}
	public string GetCurrentWindow(){
		return currentWindowName;
	}
}