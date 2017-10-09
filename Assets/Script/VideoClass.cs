using System.Collections;
using System.Collections.Generic;

public class VideoClass {

	string ID;
	float x;
	float y;
	float z;
	string VideoName;

	public VideoClass(string ID_, float x_ ,float y_ , float z_, string _name){
		ID = ID_;
		x = x_;
		y = y_;
		z = z_;
		VideoName = _name;
	}

	public float getx(){
		return x;
	}
	public float gety(){
		return y;
	}
	public float getz(){
		return z;
	}
	public string getID(){
		return ID;
	}
	public string getVideo(){
		return VideoName;
	}

	public void setx(float x_){
		x = x_;
	}
	public void sety(float y_){
		y = y_;
	}
	public void setz(float z_){
		z = z_;
	}
	public void setID(string ID_){
		ID = ID_;
	}
	public void setVideo(string video_){
		VideoName = video_;
	}
}
