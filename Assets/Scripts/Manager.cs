using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject targetObject;
    private Location targetLocation;
    private WorldLocationCalculator worldLocationCalculator;

    // Start is called before the first frame update
    void Start()
    {
        //aca bajaba la resolución no recuerdo por que, se puede sacar
        //Screen.SetResolution(800, 480, true);

        //poner una ubicación cercana para probar
        double targetLat = -38.702318;
        double targetLon = -62.271802;
        targetLocation = new Location(targetLat,targetLon);

        worldLocationCalculator = new WorldLocationCalculator();

        //llama a la función UpdateLocations cada 1 segundo
        InvokeRepeating("UpdateLocations", 0, 1f);
    }

    public void UpdateLocations()
    {
        //actualiza la posición del usuario según el GPS del teléfono
        UserLocation.singleton.UpdateLocation();
        Location userLocation = UserLocation.singleton;

        //calcula la distancia en metros entre el usuario (telefono) y el objeto target
        Vector3 newPosition = worldLocationCalculator.CalculateDistance(userLocation, targetLocation);

        //actualiza la posición del objeto target
        targetObject.transform.position = newPosition;
    }

}
