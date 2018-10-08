using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class InteractionListener : MonoBehaviour
{

    public InputField InputFieldJitter;
    public InputField InputFieldLatency;
    public InputField InputFieldRadius;
    public InputField InputFIeldNumberOfObjects;

    public Text TextExperimentStarted;
    public Text TextExperimentEnded;

    GameObject GameManagerObject;
    GameManagerScript GameManager;

    GameObject CameraManagerObject;
    CameraManagerScript CameraManager;

    // Use this for initialization
    void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
        GameManager = GameManagerObject.GetComponent<GameManagerScript>();

        CameraManagerObject = GameObject.Find("CameraManager");
        CameraManager = CameraManagerObject.GetComponent<CameraManagerScript>();

        InputFieldJitter.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
        InputFieldLatency.onValueChanged.AddListener(delegate { InputFieldLatencyChange(); });
        InputFieldRadius.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
        InputFIeldNumberOfObjects.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
    }

    void InputFieldLatencyChange()
    {
        int LatencyValue = 0;
        //Try to get parameters, if exist
        try
        {
            LatencyValue = Int32.Parse(InputFieldLatency.text);
            CameraManager.cameraLag = LatencyValue;

        }
        catch (Exception ex)
        {
            Debug.Log("Problem with parsing: " + ex);
            // Put default values;
            LatencyValue = 0;
        }
    }

    void InputFieldsChangeCheck()
    {
        Debug.Log("Values changed");
        GameManager.ReadValues();
        InitializerScript.deleteEnvironment();
        InitializerScript.createEnvironment();
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchCamera"))
        {
            CameraManager.ToggleCammera();
        }

        if (Input.GetButtonDown("EndExperiment"))
        {
            TextExperimentEnded.gameObject.SetActive(true);
            Invoke("HideStartEndLabels", 2);//this will happen after 2 seconds
            CSVWriter.Save();
        }

        if (Input.GetButtonDown("StartExperiment"))
        {
            TextExperimentStarted.gameObject.SetActive(true);
            Invoke("HideStartEndLabels", 2);//this will happen after 2 seconds
        }
    }

    void HideStartEndLabels()
    {
        TextExperimentStarted.gameObject.SetActive(false);
        TextExperimentEnded.gameObject.SetActive(false);
    }
}
