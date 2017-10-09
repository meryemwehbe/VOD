using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;


public class LocationManager : MonoBehaviour {

	public GameObject proj_sphere;
	public GameObject Player;
	public static GameObject currentLocation; // at what location is the user at this point
	public Canvas mycanvas;
	public Text debugtext;
	public GvrVideoPlayerTexture videostream;
	GameObject startLocation; // Start Location of the user --> for now it will be camera position (0 , 0 , 0 ) TODO:change  
	List<VideoClass> possibleLocations;// list of the next possible locations in area of currentLocation
	string currentVideo;



	float num_near_positions; //number of nearby possitions
	List<VideoClass> locationPositions; //List of camera locations
	string MyScene;
	string xmlName;
	TimeSpan start;
	int time_elapsed = 0;
	string urlwithtime;

	// Use this for initialization
	void Start () {
		//
		/*MyScene = SceneManager.GetArguments();
	    switch (MyScene) {
		case "Greece":
			xmlName = "PositionLocations";
			break;
		case "Classroom":
			xmlName = "ClassRoomDemo";
			break;

		}*/
		//VideoStream.videoURL = "https://storage.googleapis.com/daydream-deveng.appspot.com/japan360/dash/japan_day06_eagle2_shot0005-2880px_40000kbps.mpd";
		start = DateTime.Now.TimeOfDay;
		xmlName = "VideoPositions";
		videostream = proj_sphere.GetComponent<GvrVideoPlayerTexture>();
		Debug.Log (videostream);
		locationPositions = new List<VideoClass> ();
		possibleLocations = new List<VideoClass> ();
		startLocation = (GameObject)Instantiate (Resources.Load ("Prefabs/Location"), new Vector3 (0f, 0f, 0f), Quaternion.Euler (0, 0, 0));
		GetLocationPositions(ref locationPositions, xmlName, ref currentVideo); // get all the available locations / only done once
		Navigate(startLocation);

 	}

	// Update is called once per frame
	void Update () {
		TimeSpan duration = start.Subtract(DateTime.Now.TimeOfDay);
		debugtext.text = "Start time = " + start
		+ "\nTime now = " + DateTime.Now.TimeOfDay
		+ "\nTime elapsed = " + duration
			+ "\nurltime = "+ urlwithtime;
		//Debug.Log (GvrEditorEmulator.HeadRotation);

	}


	public void Navigate(GameObject nextLocation){
		//remove previous points

		GameObject[] presentGameObjects = GameObject.FindGameObjectsWithTag("Location");
		Debug.Log ("present gameobjects: " + presentGameObjects.Length );
		foreach (GameObject loc in presentGameObjects) {
			Destroy (loc);
		}
		possibleLocations.Clear ();


		Player.transform.position = new Vector3(nextLocation.transform.position.x, 0,nextLocation.transform.position.z) ;
		mycanvas.transform.position = new Vector3(Player.transform.position.x, 0,Player.transform.position.z + 10) ;

		proj_sphere.transform.position = nextLocation.transform.position;
		currentLocation = nextLocation;
		CalculateNearby();

		if(possibleLocations != null){
		//TODO : improve this code
		GameObject nearlocation;
		foreach (VideoClass pos in possibleLocations) {
				if (pos.getx () == currentLocation.transform.position.x &&
				   pos.getz () == currentLocation.transform.position.z) {

					currentVideo = pos.getVideo ();
					nearlocation = (GameObject)Instantiate (Resources.Load ("Prefabs/Location"), new Vector3 (pos.getx (), pos.gety (), pos.getz ()), Quaternion.Euler (0, 0, 0));

			
				} else {
					nearlocation = (GameObject)Instantiate (Resources.Load ("Prefabs/Location"), new Vector3 (pos.getx (), pos.gety () - 1, pos.getz ()), Quaternion.Euler (0, 0, 0));
				}
			}
		}
		changeVideo(currentVideo);
	}


	void CalculateNearby(){

		foreach (VideoClass video in locationPositions) {
			Debug.Log (Math.Abs (currentLocation.transform.position.x - video.getx ()));
			if (Math.Abs (currentLocation.transform.position.x - video.getx ()) < 9 && Math.Abs (currentLocation.transform.position.z - video.getz ())< 9) {
				possibleLocations.Add (video);
			}
		}
		Debug.Log( possibleLocations.Count);
	}

/*
 * Function that reads an XML file containing the positions of the camera and stores the location in an object 
 * 
 */

	public static void GetLocationPositions ( ref List<VideoClass> locationPositions , string xmlName, ref string currentVideo ) {
		//PositionLocations
		TextAsset textAsset = (TextAsset)Resources.Load (xmlName, typeof(TextAsset));
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (textAsset.text);

		XmlNodeList videos = doc.GetElementsByTagName("video");

		//videos
		foreach (XmlNode video in videos) {

			float x = 0, y = 0, z = 0;
			string videoName = "";

			foreach (XmlNode coordinate in video.ChildNodes) {


				switch (coordinate.Name){
				case "x":
					x = float.Parse (coordinate.InnerText,System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
					break;
				case "y":
					y = float.Parse (coordinate.InnerText,System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
					break;
				case "z":
					z = float.Parse (coordinate.InnerText,System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
					break;
				case "name":
					videoName = coordinate.InnerText;
					break;
				}
			}

			if (x == 0 && y == 0 && z == 0) {
				currentVideo = videoName;
			}

			VideoClass position = new VideoClass (video.Attributes["id"].Value, x, y, z,videoName);
			locationPositions.Add (position);

		}

	}




	void changeVideo(string videoName){
		TimeSpan time_elapsed = (DateTime.Now.TimeOfDay).Subtract (start);
		int time_elapsed_sec = (time_elapsed.Minutes*60 + time_elapsed.Seconds)*1000;
		urlwithtime = videoName + "?wowzaplaystart=" + time_elapsed_sec;
		videostream.videoURL = urlwithtime;
		videostream.ReInitializeVideo();
		videostream.RestartVideo ();
		//videostream.Getinfo ();
		Debug.Log(videostream.videoURL);
	}
		

}
