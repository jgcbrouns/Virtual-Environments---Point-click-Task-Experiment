using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour {

    public Camera CameraOverview;
    public Camera VRCamera;
    public Camera VRSimulatorCamera;

    List<Vector3> prevRotations = new List<Vector3>();
    public int cameraLag = 0;
    Vector3 rotateValue;

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

    private void MoveCamera()
    {
        int speed = 70;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateValue = rotateValue + new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateValue = rotateValue - new Vector3(0, speed * Time.deltaTime, 0);
        }

        prevRotations.Add(rotateValue);
        if (prevRotations.Count > cameraLag)
        {
            Vector3 value = prevRotations[0];
            prevRotations.RemoveAt(0);

            VRSimulatorCamera.transform.eulerAngles = value;
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
