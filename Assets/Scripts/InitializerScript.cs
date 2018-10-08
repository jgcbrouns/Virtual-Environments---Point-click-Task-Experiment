using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InitializerScript : MonoBehaviour {

    private static GameObject collector;

    public static List<int> rangeList;


    // Use this for initialization
    void Start () {
        //For use with object-oriented approach (right now everything is static)
		//collector = new GameObject("Collector");
        //collector.name = "Collector";
    }

    public static List<int> getRangeList()
    {
        return rangeList;
    }

    private static int getRandomIntForRange(int radiusUpperbound)
    {
        Random r = new Random();
        return r.Next(2, radiusUpperbound);
    }

    private static List<int> getFixedRangeArray(int radiusUpperbound, int amountOfCones)
    {
        List<int> list = new List<int>();

        // For every cone, decrease radius with 1
        for (int i=1; i <= amountOfCones+1; i++)
        {
            list.Add(radiusUpperbound-(i+2));
        }

        return list;
    }

    private static Random rng = new Random();

    public static List<int> Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }

    internal static void createEnvironment()
    {
        if(collector == null)
        {
            collector = new GameObject("Collector");
            collector.name = "Collector";
        }

        Debug.Log("Creating environment");
        /* Definition of circle:
         * (x−h)^2+(y−k)^2=r^2
         * h and k are the x and y coordinates of the center of the circle
         * 
         * x = cx + r * cos(a)
         * y = cy + r * sin(a)
         * Where r is the radius, cx,cy the origin, and a the angle.
         */

        int radiusUpperbound = GameManagerScript.RadiusValue;
        rangeList = getFixedRangeArray(radiusUpperbound, GameManagerScript.NumberOfObjectsValue);
        rangeList = Shuffle(rangeList);

        Debug.Log("items in list: "+rangeList.Count);
        Debug.Log("first item: "+rangeList[0]);
        Debug.Log("last item: " + rangeList[rangeList.Count-1]);

        float cx = 0;
        float cz = 0;

        //List<int> heights = [23, 24];

        double stepsize = 180 / GameManagerScript.NumberOfObjectsValue;
        //Debug.Log("Stepsize: " + stepsize);
        int counter = 0;
        for (double a = 0; a <= 180; a=a+stepsize)
        {
            int radius = rangeList[counter];
            float x = (float)(cx + radius * Math.Cos(ConvertToRadians(a)));
            float z = (float)(cz + radius * Math.Sin(ConvertToRadians(a)));

            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(x, 0, z);
            cylinder.transform.localScale = new Vector3(1, UnityEngine.Random.Range(1, 5), 1);
            cylinder.transform.parent = collector.transform;

            counter++;
        }

        //CSVWriter.Save(rangeList);
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
