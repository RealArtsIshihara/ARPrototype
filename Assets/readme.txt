================================================================================
VideoPlayback
================================================================================
This sample application shows how to play a video in AR mode.
Devices that support video on texture can play the video directly on the image 
target. Other devices will play the video in full screen mode.

================================================================================
How to build the sample
================================================================================
The sample depends on the Vuforia Unity Extension.
Import this package and one or both of the following packages:
  vuforia-android-x-y-z.unitypackage
  vuforia-ios-x-y-z.unitypackage

================================================================================
Notes
================================================================================
 - Unity 3.5+ is recommended
 - OpenGL ES 2.0 is required
 - iOS full screen mode does not pause the Unity engine

================================================================================
How to use the sample
================================================================================
1. You need to print the stones and chips image targets to use this app.  This 
image is available in the media directory of the sample code package.

2. After you start the app, point the camera to the stones target image and a 
video frame will appear on top of the target.  

3. Tap the play button on the screen to start the video.  Devices that support 
video on texture will play the video on the image target.  Other devices will 
play the video in full screen mode.

================================================================================
How to change the video
================================================================================
1. Expand one of the Image Targets in the Hierarchy and select the Video child
object.

2. In the Inspector view, change the Video Playback Behaviour > Path setting.
This can point to a file in the StreamingAssets folder, on the sdcard, or a
remote file.

================================================================================
Known issues
================================================================================
It has been noticed that in some environments the startup screen is not centered
when in landscape mode for the iPhone 4S.

Buffering feedback is not displayed on Android devices when playing the video
in fullscreen mode.

================================================================================
Tips and tricks
================================================================================
We recommend using videos in H.264 format with AAC audio for maximum 
compatibility across all platforms.

Android's guide to supported media formats can be found here:
http://developer.android.com/guide/appendix/media-formats.html