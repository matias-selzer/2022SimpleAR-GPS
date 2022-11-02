using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserLocation : Location {

	public static UserLocation singleton;

	// Use this for initialization
	public UserLocation () {
		if (singleton == null)
			singleton = this;
		lat = -38.700103;
		lon = -62.268613;
	}

	public void UpdateLocation(){
        #if UNITY_EDITOR
                //Debug.Log("editor");
        #elif UNITY_ANDROID
			    lat=Input.location.lastData.latitude;
			    lon=Input.location.lastData.longitude;
        #endif
    }



}
