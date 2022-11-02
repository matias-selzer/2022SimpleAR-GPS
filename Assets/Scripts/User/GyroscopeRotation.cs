using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GyroscopeRotation : MonoBehaviour {

	Gyroscope gyro;
	Quaternion gyroInitialRotation;

	float defasaje=0;
	float oldGrados=0;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		gyro = Input.gyro; // Store the reference for Gyroscope sensor 
		gyro.enabled = true; //Enable the Gyroscope sensor 

		gyroInitialRotation = new Quaternion(Input.gyro.attitude.x,Input.gyro.attitude.y,Input.gyro.attitude.z,Input.gyro.attitude.w);
		Input.location.Start ();
		Input.compass.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
        #if UNITY_EDITOR
        //Debug.Log("editor");
        #elif UNITY_ANDROID
        actualizarDatosGyro ();
		#endif
	}
		

	public void actualizarDatosGyro(){
		Quaternion nuevo = Input.gyro.attitude;

		nuevo.x*=-1.0f;
		nuevo.y*=-1.0f;
		nuevo = Quaternion.Euler(90, 0, 0)*nuevo;

		nuevo.eulerAngles=new Vector3(nuevo.eulerAngles.x,nuevo.eulerAngles.y-defasaje,nuevo.eulerAngles.z);

		transform.localRotation =  nuevo;
	}

	//esto es por si queres guardar la posición actual como el cero, o calibrar
	public void guardar(){
		gyroInitialRotation=Input.gyro.attitude;
		gyroInitialRotation.x*=-1.0f;
		gyroInitialRotation.y*=-1.0f;
		gyroInitialRotation = Quaternion.Euler(90, 0, 0)*gyroInitialRotation;

		defasaje=gyroInitialRotation.eulerAngles.y;

	
	}
	

}
