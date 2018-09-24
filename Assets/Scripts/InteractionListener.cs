using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionListener : MonoBehaviour
{

    public InputField InputFieldJitter;
    public InputField InputFieldLatency;
    public InputField InputFieldRadius;
    public InputField InputFIeldNumberOfObjects;

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
        InputFieldLatency.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
        InputFieldRadius.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
        InputFIeldNumberOfObjects.onValueChanged.AddListener(delegate { InputFieldsChangeCheck(); });
    }

    void InputFieldsChangeCheck()
    {
        Debug.Log("Values changed");
        GameManager.ReadValues();
        InitializerScript.deleteEnvironment();
        InitializerScript.createEnvironment();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SwitchCamera"))
        {
            CameraManager.ToggleCammera();
        }
    }
}
