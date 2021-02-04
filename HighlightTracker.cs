using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightTracker : MonoBehaviour {

    //A script attached to the Select menu, this code keeps track of the points currently highlighted by the user and updates the text field to show it.
    //Possible improvments include a dropdown or scrollbar feature to accomodate for cases where there is not enough space allocated to display all of the object names,
    //However this implementation has proved challenging in VR

    public GameObject tagMaster;

	void Start () {
        tagMaster = GameObject.Find("tagMaster");
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Text>().text = "Currently highlighted points: \n";

		foreach(GameObject point in tagMaster.GetComponent<textParser>().objectList)
        {
            if (point.GetComponent<ObjBehavior>().Selected)
            {
                GetComponent<Text>().text += point.name + "\n";
            }
        }
	}
}
