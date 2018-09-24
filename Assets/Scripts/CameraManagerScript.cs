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
        //StartCoroutine(ExecuteAfterTime(0.5f, () =>
        //{
        //    MoveCamera();
        //}));
    }

    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    private Vector3 currentAngle;
    private Vector3 offset;
    //public float delay = 2f; //For example here it waits 2 seconds.
    public float followNow;


    //void Start()
    //{
    //    followNow = Time.time + delay;
    //    offset = transform.position;
    //}

    //void LateUpdate()
    //{
    //    if (Time.time > followNow)
    //    {
    //        if (player != null)
    //        {
    //            transform.position = player.transform.position + offset;
    //        }
    //        followNow += delay;
    //    }
    //}

    Vector3 rotateValue;

    internal void MoveCamera()
    {
        int speed = 70;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            followNow = Time.time + 0.5f;
            Debug.Log(followNow);
            rotateValue = rotateValue + new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log(rotateValue);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            followNow = Time.time + 0.5f;
            Debug.Log(followNow);
            rotateValue = rotateValue - new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log(rotateValue);
        }

        Debug.Log("follow_now timestamp: "+followNow+"   current time stamp: "+Time.time);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            VRSimulatorCamera.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            VRSimulatorCamera.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        if (Time.time > followNow)
        {
            Debug.Log("I expired");
            currentAngle = VRSimulatorCamera.transform.eulerAngles;

            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, rotateValue.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, rotateValue.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, rotateValue.z, Time.deltaTime)
            );

            VRSimulatorCamera.transform.eulerAngles = currentAngle;
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
