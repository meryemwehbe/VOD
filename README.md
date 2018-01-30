# Streaming On Demand

This android application demonstrates a multi-view scenario which is similar to the Google Street View VR app, but instead of having still images, actually having live 360 videos.

The user will experience, in VR (Virtual Reality), a live demonstration of a certain scenery (a classroom, theatre, outdoors etc). He or she will be able to switch his or her view from one camera position to another and therefore navigate in the scene.

For this, multiple 360 cameras will be live streaming simultaneously, at different locations of the scene over the 5G network. The essential feature of the 5G network lies in forwarding the streams to the VR client with very low latency, which it is designed for. This gives the viewer a live experience of being in the scene. 

The challenges of this project are many. One is the hardware required, as for each view point, a 360 camera is needed. Also a lot of bandwidth and memory is needed to stream and process the videos. Therefore EPFL, in collaboration with Swisscom, is working on the synthesis of new views using the contents of two other positions. For this reason, instead of having three cameras streaming the view from three different positions, only two cameras are used at two positions, and the third position (and fourth and fifth …) is synthesized. This will cut back tremendously in the equipment, memory and bandwidth needed to create such an application.

## Prerequisites

* Unity on pc 
* A phone compatible with Google Daydream and Cardboard 
* Wowza Streaming Engine Account
* Phone and Wowza server connected to the same network 
	
## Setup the Orah cameras and configure them with the Wowza Streaming Engine 
### Wowza Streaming Engine

* Create an Account on Wowza and setup the engine on your local computer
* Create a video-on-demand application with wowza  https://www.wowza.com/docs/how-to-set-up-video-on-demand-streaming
* Place the ready videos that you want included in the application in your Wowza Directory: WowzaStreamingEngine4.7.1/content 
* Make sure your Firewall settings are open for a private network

### Setting up the Orah Cameras 
* Follow the Orah manual to access the home page of the cameras (make sure camera and stiching box are well connected)
* Follow this tutorial step by step to configure the cameras to stream to the Wowza Streaming Engine:
 https://support.orah.co/hc/en-us/articles/207316010-How-to-live-stream-with-the-Orah-4i-and-Wowza [2]	
* However, in the above tutorial, instead of configuring the camera with the live application, configure it with the video-on-demand application (change of name of app in rtmp url)

## Unity Project Installation
### Download Unity and Configure on pc
* Clone this repository and open it the project with Unity
* In Unity, Assets -> Import Package -> Custom Package -> GoogleVRForUnity_1.70.0.unitypackage -> Import All Assets
* Make sure you have the right android sdk installed on your laptop. 
	You can follow the instructions here: https://docs.unity3d.com/Manual/android-sdksetup.html
	
### If Video Doesn't Project Correctly
* Click on the Octahedron Sphere Tester Object
* Go to VideoSphere and make sure GoogleVR/Video Unlit Shader is selected
* Make sure stereomode is set to none
* You can also flip the x-axis

### Change Videos and Video Positions
* In the project folder, go to Assets -> Resources -> VideoPositions.xml
* Replace the name tag by the url of the video : http://[IP-Wowza-Server]:Port#/[wowza vod app name]/mp4:[videoname].mp4/manifest.mpd
	(IP-Wowza-Server is found on the Wowza Engine homepage in the left column)
* Change x,y,z coordinates according to camera positions in the scene on the unity axis [see unity manual for more]
    
## Build Project on Phone	
* Go to File - > Build Settings ->  Select Android platform
* Go to File - > Build Settings -> Player Settings 
* In XR Settings, check the Virtual Supported Box and add Daydream and Cardboard to the SDK's
* In Other Settings, specify a package name, version , Minimum API Level (advised 7.0)
* Select External SD for write permission
* Connect the phone to the pc and make sure it is in Debug Mode
* File - > Build and Run 
* Make sure the app is given permission to access the phone's storage on the device as well.
	

