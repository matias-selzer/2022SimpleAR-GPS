using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebcamPlayer : MonoBehaviour {

	public RawImage rawimage;
	void Start () 
	{
		WebCamTexture webcamTexture = new WebCamTexture();
		//vamos a probar si esto hace que se vea bien
		webcamTexture.requestedWidth=(Screen.width);
		webcamTexture.requestedHeight= (Screen.height);

		webcamTexture.requestedFPS =(30);

		rawimage.texture = webcamTexture;
		rawimage.material.mainTexture = webcamTexture;
		webcamTexture.Play();

	}
}
