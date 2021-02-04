using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

/*
 * A small, obscure class that is capable of creating and writing to a file, in this case recording a user's selection in CSV format
 */

public class PrintSelection : MonoBehaviour {

    //the master object with the list of all points in the scene
    public GameObject tagMaster;

    void Start()
    {
        //initialize reference
        tagMaster = GameObject.Find("tagMaster");
    }

    public void printToText()
    {
        //create a file if there is none
        string path = "Assets/Resources/TextFiles/_CSVOutput.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "List of points selected from scene " + SceneManager.GetActiveScene().name + ":\n\n");
        }

        string content = "";

        //check all points, and add the point's name to text if it's selected
        foreach(GameObject point in tagMaster.GetComponent<textParser>().objectList)
        {
            if(point.activeInHierarchy && point.GetComponent<ObjBehavior>().Selected)
            {
                content += point.name + ",";
            }
        }
        if(content.Length > 0)
        {
            //print!
            content = content.Substring(0, content.Length - 1);
            File.AppendAllText(path, content + "\n");
        }
    }
}
