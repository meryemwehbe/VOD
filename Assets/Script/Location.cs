using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class Location : MonoBehaviour {

	public GameObject proj_sphere;
	VideoPlayer videoPlayer;
	GameObject locationManager;
	Color colorEnter = Color.green;
	Color colorExit = Color.white;
	float duration = 1.0F;
	Renderer rend;

	void Start(){
		rend = GetComponent<Renderer> ();
		locationManager = GameObject.FindWithTag("MyLocationManager");	
		videoPlayer = proj_sphere.GetComponent<VideoPlayer> ();
	}

	public void ChangePosition(){
		locationManager.GetComponent <LocationManager>().Navigate (this.gameObject);
	}

	public void ChangeColorEnter(){
		float lerp = Mathf.PingPong(Time.time,duration)/duration;
		rend.material.color = Color.Lerp(rend.material.color, colorEnter, lerp);
	}
	public void ChangeColorExit(){
		float lerp = Mathf.PingPong(Time.time,duration)/duration;
		rend.material.color = Color.Lerp(rend.material.color, colorExit, lerp);
	}

	public void Return(){
		Debug.Log ("yesssssssssss");
		SceneManager.LoadScene ("startSceen", "");
	}

}
