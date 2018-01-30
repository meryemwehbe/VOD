using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartVideo : MonoBehaviour {
	GvrVideoPlayerTexture texture;
	VideoControlsManager video_control;
	//public Text debugtext;
	public bool enter_no = false , enter_yes = false;
	// Use this for initialization
	void Start () {
		texture = GetComponent<GvrVideoPlayerTexture> ();

	

	}
	
	// Update is called once per frame
	void Update () {
		if (texture.Play () && !enter_yes) {
			//Sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			//Sphere.transform.position = new Vector3 (5, 0, 0);
			//debugtext.text = "video ready";
			enter_yes = true;
		} else if(!enter_no){
			//Cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			//Cube.transform.position = new Vector3 (-5, 0, 0);
			//debugtext.text = "not ready ";
			enter_no = true;
		}
	}
}
