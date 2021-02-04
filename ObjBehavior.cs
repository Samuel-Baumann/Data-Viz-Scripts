using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * This class is responsible for keeping track of the states of a point in the scene, and this script is attached to each point upon creation in tagMaster
 */

public class ObjBehavior : MonoBehaviour {

    //Needed references and prefabs
    public Material highlightMat;
    public Material initialMat;
    public bool Selected = false;

    public string psuedoTag;

    public GameObject canvasReference;
    public Canvas canvasClone;

    void Start()
    {
        //load the required information
        initialMat = gameObject.GetComponent<Renderer>().material;
        canvasReference = (GameObject)Resources.Load("Prefabs/objCanvas");
        highlightMat = (Material)Resources.Load("Image&Mats/Materials/defaultHigh");
    }

    //Update is called once every frame, and here we check if the point is selected
    void Update()
    {
        if (Selected)
        {
            //if it is, we ensure that the text above the point always looks at the player's position
            canvasClone.transform.LookAt(GameObject.Find("VRPlayer").transform.position - new Vector3(0, 1f, 0));
            canvasClone.transform.Rotate(0, 180, 0); //rotate to face the correct way, as 'forward' for a canvas faces away from the player
        }
    }

    //This method can be called from outside sources, and highlights the point while projecting its name above itself, or reverts it back to its default state if it was already selected
    public void Toggle()
    {
        if (!Selected)
        {
            gameObject.GetComponent<Renderer>().material = highlightMat;

            canvasClone = Instantiate(canvasReference).GetComponent<Canvas>();
            canvasClone.transform.position = transform.position + new Vector3(0, 1, 0);
            canvasClone.transform.localScale *= 3;
            canvasClone.transform.SetParent(transform);
            canvasClone.GetComponentInChildren<Text>().text = gameObject.name;
            canvasClone.name = gameObject.name + " tempCanvas";
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = initialMat;
            Destroy(GameObject.Find(gameObject.name + " tempCanvas"));
        }

        Selected = !Selected;
    }
}
