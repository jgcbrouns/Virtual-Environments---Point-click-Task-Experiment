using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerScript : MonoBehaviour {

    private static GameObject collector;

    // Use this for initialization
    void Start () {
		collector = new GameObject("Collector");
        collector.name = "Collector";
    }

    internal static void createEnvironment()
    {
        Debug.Log("Creating environment");
        /* Definition of circle:
         * (x−h)^2+(y−k)^2=r^2
         * h and k are the x and y coordinates of the center of the circle
         * 
         * x = cx + r * cos(a)
         * y = cy + r * sin(a)
         * Where r is the radius, cx,cy the origin, and a the angle.
         */

        int radius = GameManagerScript.RadiusValue;
        float cx = 0;
        float cz = 0;

        double stepsize = 180 / GameManagerScript.NumberOfObjectsValue;
        Debug.Log("Stepsize: " + stepsize);
        for (double a = 0; a <= 180; a=a+stepsize)
        {
            float x = (float)(cx + radius * Math.Cos(ConvertToRadians(a)));
            float z = (float)(cz + radius * Math.Sin(ConvertToRadians(a)));

            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(x, 0, z);
            cylinder.transform.localScale = new Vector3(1, UnityEngine.Random.Range(1, 5), 1);
            cylinder.transform.parent = collector.transform;
        }
    }

    public static double ConvertToRadians(double angle)
    {
        return (Math.PI / 180) * angle;
    }

    internal static void deleteEnvironment()
    {
        foreach (Transform child in collector.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
