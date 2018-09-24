using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour {

    public Camera CameraOverview;
    public Camera VRCamera;
    public Camera VRSimulatorCamera;

    // Use this for initialization
    void Start () {
        CameraOverview.enabled = true;
        VRCamera.enabled = false;
        VRSimulatorCamera.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
    }

    internal void MoveCamera()
    {
        int speed = 70;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rotateValue = new Vector3(0, -speed * Time.deltaTime, 0);
            VRSimulatorCamera.transform.eulerAngles = VRSimulatorCamera.transform.eulerAngles - rotateValue;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 rotateValue = new Vector3(0, speed * Time.deltaTime, 0);
            VRSimulatorCamera.transform.eulerAngles = VRSimulatorCamera.transform.eulerAngles - rotateValue;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            VRSimulatorCamera.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            VRSimulatorCamera.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    internal void ToggleCammera()
    {
        Debug.Log("Toggle camera");
        if (CameraOverview.enabled == true)
        {
            Debug.Log("1");
            VRSimulatorCamera.enabled = true; 
            CameraOverview.enabled = false;

        }
        else if (CameraOverview.enabled == false)
        {
            Debug.Log("2");
            CameraOverview.enabled = true;
            VRSimulatorCamera.enabled = false;
        }
    }
}
