using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;


public class followCamera : MonoBehaviour {
	public Camera MainCamera;
	public GvrEditorEmulator em;
	public Text displaytext;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (MainCamera.transform.position.x, MainCamera.transform.position.y, 5);
		//displaytext.text = " time = " + Network.time ;//+ "\n x = "+ GvrEditorEmulator.HeadRotation.x
			//+ "\n y = "+ GvrEditorEmulator.HeadRotation.y + "\n z = "+ GvrEditorEmulator.HeadRotation.z;
	
	}
}
