using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A simple class needed to create and keep track of the search field a user wishes to explore the scene with
 */

public class SpawnField : MonoBehaviour {

    //necessary prefabs and references to objects in scene
    public GameObject player;
    public GameObject fieldReference;
    public GameObject newQBox;
    public GameObject centroidReference;
    public GameObject newRoid;

    //Update is called once per frame, and here we check if any of our references are missing (which they should be unless the user manually assigned them, which is good but uneeded)
    //If they are, we assign them accordingly, and if they weren't the user might have customized in some way, so we assume they know what they're doing.
    //Assigning references is usually done in the Start() method, but having them in update means that if an objcet doesn't yet exist in the scene, we can catch them by checking each time.
    //This checks a small amount of if statementseach frame, but ultimately does not hinder performance too much, and allows for the user to create and destroy search fields without issue.
    void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("VRPlayer");
        }

        if(fieldReference == null && transform.name == "NewCubeFieldButton")
        {

            fieldReference = (GameObject)Resources.Load("Prefabs/Pivot");
        }

        if (fieldReference == null && transform.name == "NewSphereFieldButton")
        {

            fieldReference = (GameObject)Resources.Load("Prefabs/PivotSphere");
        }

        if (centroidReference == null)
        {
            centroidReference = (GameObject)Resources.Load("Prefabs/Centroid");
        }

        if(newQBox == null && GameObject.Find("Pivot(Clone)"))
        {
            newQBox = GameObject.Find("Pivot(Clone)");
        }
    }

    //responsible for instantiating the field and the centroid, and naming them accordingly
	public void create()
    {
        newRoid = Instantiate(centroidReference);
        newRoid.transform.position = player.transform.position + new Vector3(0.5f, -1.5f, 4.5f);
        newRoid.name = "newRoid";
        newQBox = Instantiate(fieldReference);
        newQBox.transform.position = player.transform.position + new Vector3 (0, -2, 4);
        newQBox.name = "Pivot(Clone)";
    }

    //a small public method that allows outside sources to change whether or not we want to move the field or resize it
    public void switchMode()
    {
        if(newQBox != null)
        {
            newQBox.GetComponent<QBoxResize>().moving = !newQBox.GetComponent<QBoxResize>().moving;
        }
    }
}
