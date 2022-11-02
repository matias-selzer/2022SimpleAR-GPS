using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLocationCalculator
{
    static readonly double R = 6371.0; // Radius of the earth in km
    static readonly double pi_sobre_180 = Math.PI / 180.0;

	//metodo que devuelve la distancia en unidades Unity entre dos Location
	public Vector3 CalculateDistance(Location userLocation, Location poiLocation)
	{
		Vector3 newPos;

		Location projectionY = new Location(poiLocation.lat, userLocation.lon);
		Location projectionX = new Location(userLocation.lat, poiLocation.lon);
		double distX = CalculateDistanceKM(userLocation, projectionX);
		double distY = CalculateDistanceKM(userLocation, projectionY);

		if (poiLocation.lat < userLocation.lat)
			distY *= -1.0;

		if (poiLocation.lon < userLocation.lon)
			distX *= -1.0;

		newPos = new Vector3(((float)(distX * 1000)), 3, ((float)(distY * 1000)));

		return newPos;
	}

	public double CalculateDistanceKM(Location p1, Location p2)
	{
		double dLat = (p2.lat - p1.lat) * pi_sobre_180;  // deg2rad below
		double dLon = (p2.lon - p1.lon) * pi_sobre_180;

		double a =
			Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
			Math.Cos(p1.lat * pi_sobre_180) * Math.Cos(p2.lat * pi_sobre_180) *
			Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

		double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
		double d = R * c; // Distance in km

		return d;
	}
}
