using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{

    private static List<string[]> rowData;

    // Use this for initialization
    void Start()
    {
        //Save();
    }

    public static void Save()
    {
        List<int> ConeRadiusList = InitializerScript.getRangeList();

        rowData = new List<string[]>();

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = "cone_number";
        rowDataTemp[1] = "cone_height";
        rowDataTemp[2] = "Task_completion_time";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for (int i = 0; i < ConeRadiusList.Count; i++)
        {
            rowDataTemp = new string[3];
            rowDataTemp[0] = ConeRadiusList[i].ToString();
            rowDataTemp[1] = "?";
            rowDataTemp[2] = "?";
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "experiment_"+ DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }
}
