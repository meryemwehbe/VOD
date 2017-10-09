using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager {

	public static string arguments;
	// Use this for initialization
	public static void LoadScene (string Scene , string args) {
		arguments = args;
		Application.LoadLevel(Scene);
	}
	
	// Update is called once per frame
	public static string GetArguments () {
		return arguments;
	}
}
