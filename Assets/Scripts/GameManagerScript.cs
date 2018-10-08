using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public InputField InputFieldJitter;
    public InputField InputFieldLatency;
    public InputField InputFieldRadius;
    public InputField InputFIeldNumberOfObjects;

    public static int JitterValue;
    public static int LatencyValue;
    public static int RadiusValue;
    public static int NumberOfObjectsValue;

    public static int defaultValue = 5;

    // Use this for initialization
    void Start () {
        this.ReadValues();
        InitializerScript.createEnvironment();
	}

    public void ReadValues()
    {
        Debug.Log("Reading values");

        //Try to get parameters, if exist
        try
        {
            JitterValue = Int32.Parse(InputFieldJitter.text);
 
        }
        catch (Exception ex)
        {
            Debug.Log("Problem with parsing: "+ ex);
            // Put default values;
            JitterValue = defaultValue;
        }

        //Try to get parameters, if exist
        try
        {
            RadiusValue = Int32.Parse(InputFieldRadius.text);

        }
        catch (Exception ex)
        {
            Debug.Log("Problem with parsing: " + ex);
            // Put default values;
            RadiusValue = 17;
        }

        //Try to get parameters, if exist
        try
        {
            NumberOfObjectsValue = Int32.Parse(InputFIeldNumberOfObjects.text)-1;

        }
        catch (Exception ex)
        {
            Debug.Log("Problem with parsing: " + ex);
            // Put default values;
            NumberOfObjectsValue = 5;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
