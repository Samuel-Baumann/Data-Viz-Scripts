using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This is the main class in the project, and is responsible for all user interaction within the scene. This class will get information about whatever the user
 * hits with their laser and call the appropriate functions found in scripts attached to those objects, and also takes care of colors and other small visual details
 * to help the user feel more immersed in the scene. Possible edits in future could attempt to make this class smaller, and compartmentalize some funcitonality.
 * 
 * April 2019 Update: changed all references to tagMaster.getComponent<TagCreator>() to tagMaster.getComponent<textParser>() and introduced the dynamically scaling zapper 
 * that resizes itself on hitting an object. This class is becoming larger and larger, and splitting it into smaller, more manageable pieces is reccomended if more features are added to the left hand.
 */

public class Zapper : MonoBehaviour {

    //the billboard
    public GameObject billboard;

    //for spawning the laser itself
    public GameObject lineReference;
    public GameObject lineClone;
    public float range = 100f;

    //the object we hit
    public GameObject tempZapped;
    public GameObject tempZapped2;
    public GameObject oldZapped;

    //change the main help text the user sees
    public Text mainText;

    //canvases to be activated or deactivated upon hitting a button
    public GameObject layerCanvas, findCanvas, queryCanvas;

    //the aforementioned buttons, plus a few others
    public GameObject printButton;
    public GameObject deleteButton;
    public GameObject cubeSearchButton;
    public GameObject sphereSearchButton;
    public GameObject switchModeButton;

    //a list of numeric buttons, primarily for color change
    public List<GameObject> numericButtons;

    //a reference to the object with the list of all points in the scene
    public GameObject tagMaster;

    //checking to see if we can spawn a new search field
    public bool boxExists = false;

    //a better gray than the default gray
    Color32 newGray = new Color32(200, 200, 200, 255);

    public bool toggleMode = true;

    //possible haptic / audio feedback info that you can play around with
    public byte[] noize = { 255 };

    public AudioClip beep;
    public AudioSource source;

    //Start will simply locate all needed objects in the scene, avoiding tedious clicking and dragging to assign references by hand.
    //It can also make sure objects that are supposed to be invisible start invisible!
	void Start ()
    {
        source = GameObject.Find("CenterEyeAnchor").GetComponent<AudioSource>();

        lineClone = Instantiate(lineReference);
        lineClone.transform.SetParent(transform);
        lineClone.transform.position = transform.position + new Vector3(-0.03f, 0, 0);

        lineClone.gameObject.SetActive(false);
        lineClone.GetComponent<LineRenderer>().startColor = Color.red;

        mainText = GameObject.Find("MainText").GetComponent<Text>();

        printButton = GameObject.Find("PrintButton");
        deleteButton = GameObject.Find("DeleteButton");
        cubeSearchButton = GameObject.Find("NewCubeFieldButton");
        sphereSearchButton = GameObject.Find("NewSphereFieldButton");
        switchModeButton = GameObject.Find("SwitchModeButton");

        numericButtons = new List<GameObject>() { GameObject.Find("Alpha1"), GameObject.Find("Alpha2"), GameObject.Find("Alpha3"), GameObject.Find("Alpha4"),
                                                  GameObject.Find("Alpha5"), GameObject.Find("Alpha6"), GameObject.Find("Alpha7"), GameObject.Find("Alpha8"),
                                                  GameObject.Find("Alpha9"), GameObject.Find("Alpha0"), GameObject.Find("AlphaBack"), GameObject.Find("AlphaSearch"), GameObject.Find("AlphaClear") };

        layerCanvas = GameObject.Find("LayerMenu");
        layerCanvas.SetActive(false);
        findCanvas = GameObject.Find("FindMenu");
        findCanvas.SetActive(false);
        queryCanvas = GameObject.Find("QueryMenu");
        queryCanvas.SetActive(false);
        tagMaster = GameObject.Find("tagMaster");
    }
	
	// Update is called once per frame, and is where all user input is handled.
	void Update () {

        //MasterhitInfo was part of the April 2019 update, and resizes the laser. It also vibrates slightly to give a user a better idea if they've hit something
        RaycastHit masterHitInfo;

        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            foreach(GameObject point in tagMaster.GetComponent<textParser>().objectList)
            {
                if (point.GetComponent<ObjBehavior>().Selected)
                {
                    point.GetComponent<ObjBehavior>().Toggle();
                }
            }
        }

        if (Physics.Raycast(transform.position, transform.forward, out masterHitInfo, 100))
        {
            tempZapped2 = GameObject.Find(masterHitInfo.transform.name);

            if (lineClone.activeInHierarchy && oldZapped != tempZapped2)
            {
                OVRHaptics.Channels[0].Preempt(new OVRHapticsClip(noize, 1));
                //source.PlayOneShot(beep);
            }
            oldZapped = tempZapped2;

            lineClone.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, Vector3.Distance(transform.position, tempZapped2.transform.position)));

        }
        else
        {
            lineClone.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 100));
            tempZapped2 = null;
            oldZapped = null;
        }

        //these clauses spawn in the laser(red, not shooting a raycast)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            lineClone.gameObject.SetActive(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            lineClone.gameObject.SetActive(false);
        }

        //this is where the magic happens, and a raycast is shot by the laser, turning it white and getting info about what we hit
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && lineClone.gameObject.activeInHierarchy == true)
        {
            lineClone.GetComponent<LineRenderer>().startColor = Color.white;
            RaycastHit hitInfo;

            if(Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
            {
                tempZapped = GameObject.Find(hitInfo.transform.name);
                Debug.Log(tempZapped.name);

                //change scale of line if possible to make it more immersive? In progress
                //lineClone.transform.localScale = new Vector3(lineClone.transform.localScale.x, lineClone.transform.localScale.y, Vector3.Distance(transform.position, tempZapped.transform.position));

                //The following if statements are self evident: if we hit X, do Y behavior. These can be treated as a black box unless something goes horribly wrong
                if (tempZapped.GetComponent<ObjBehavior>() && toggleMode)
                {
                    tempZapped.GetComponent<ObjBehavior>().Toggle();
                }

                if(tempZapped.name == "HomeButton")
                {
                    tempZapped.GetComponent<Image>().color = newGray;
                    SceneManager.LoadScene("StartScreen");
                }

                if(tempZapped.name == "LayerButton")
                {
                    if (layerCanvas.activeInHierarchy)
                    {
                        layerCanvas.SetActive(false);
                        tempZapped.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        layerCanvas.SetActive(true);
                        tempZapped.GetComponent<Image>().color = newGray;
                    }
                }

                if (tempZapped.name == "FindButton")
                {
                    if (findCanvas.activeInHierarchy)
                    {
                        findCanvas.SetActive(false);
                        tempZapped.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        findCanvas.SetActive(true);
                        tempZapped.GetComponent<Image>().color = newGray;
                    }
                }

                if (tempZapped.name == "QueryButton")
                {
                    if (queryCanvas.activeInHierarchy)
                    {
                        queryCanvas.SetActive(false);
                        tempZapped.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        queryCanvas.SetActive(true);
                        tempZapped.GetComponent<Image>().color = newGray;
                    }
                }

                if (tempZapped.tag == "toggleButton")
                {
                    tempZapped.GetComponent<Toggle>().isOn = !tempZapped.GetComponent<Toggle>().isOn;

                    foreach (GameObject point in tagMaster.GetComponent<textParser>().objectList)
                    {
                        if(point.GetComponent<ObjBehavior>().psuedoTag == tempZapped.name)
                        {
                            if (point.activeInHierarchy)
                            {
                                point.SetActive(false);
                            }
                            else
                            {
                                point.SetActive(true);
                            }
                        }
                    }

                    if (tempZapped.name.StartsWith("Vectorfield"))
                    {
                        foreach (GameObject arrow in GameObject.Find("tagMaster").GetComponent<textParser>().arrows)
                        {
                            if (arrow.GetComponent<arrowProperties>().vectorNumber == int.Parse(tempZapped.name.Substring(tempZapped.name.Length - 1)))
                            {
                                if (arrow.activeInHierarchy)
                                {
                                    arrow.SetActive(false);
                                }
                                else
                                {
                                    arrow.SetActive(true);
                                }
                            }
                        }
                    }
                    if (tempZapped.name.StartsWith("wrapper"))
                    {
                        for(int i = 0; i < GameObject.Find("triangles").transform.childCount; i++)
                        {
                            if(GameObject.Find("triangles").transform.GetChild(i).name == tempZapped.name)
                            {
                                if (GameObject.Find("triangles").transform.GetChild(i).gameObject.activeInHierarchy)
                                {
                                    GameObject.Find("triangles").transform.GetChild(i).gameObject.SetActive(false);
                                }
                                else
                                {
                                    GameObject.Find("triangles").transform.GetChild(i).gameObject.SetActive(true);
                                }
                            }
                        }
                    }

                    if (tempZapped.name.StartsWith("Linked Set"))
                    {
                        for (int i = 0; i < GameObject.Find("linkedSets").transform.childCount; i++)
                        {
                            if (GameObject.Find("linkedSets").transform.GetChild(i).name == tempZapped.name)
                            {
                                if (GameObject.Find("linkedSets").transform.GetChild(i).gameObject.activeInHierarchy)
                                {
                                    GameObject.Find("linkedSets").transform.GetChild(i).gameObject.SetActive(false);
                                }
                                else
                                {
                                    GameObject.Find("linkedSets").transform.GetChild(i).gameObject.SetActive(true);
                                }
                            }
                        }
                    }

                    if(tempZapped.name == "Billboard")
                    {
                        if (billboard.activeInHierarchy)
                        {
                            billboard.SetActive(false);
                        }
                        else
                        {
                            billboard.SetActive(true);
                        }
                    }

                }

                if (tempZapped.name == "PrintButton")
                {
                    tempZapped.GetComponent<PrintSelection>().printToText();
                    tempZapped.GetComponent<Image>().color = newGray;
                    mainText.text = "Printing the list of selected objects to file: Assets/Resources/_CSVOutput...";
                }

                if (tempZapped.tag == "numeric")
                {
                    tempZapped.GetComponent<KeypadBehavior>().act();
                    tempZapped.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                }

                if(tempZapped.name == "NewSphereFieldButton" || tempZapped.name == "NewCubeFieldButton")
                {
                    if (!boxExists)
                    {
                        tempZapped.GetComponent<SpawnField>().create();
                        boxExists = true;
                        tempZapped.GetComponent<Image>().color = newGray;
                    }
                }

                if(tempZapped.name == "SwitchModeButton")
                {

                    if (tempZapped.GetComponent<Image>().color == Color.white)
                    {
                        tempZapped.GetComponent<Image>().color = newGray;
                        tempZapped.GetComponentInChildren<Text>().text = "Moving";
                    }
                    else
                    {
                        tempZapped.GetComponent<Image>().color = Color.white;
                        tempZapped.GetComponentInChildren<Text>().text = "Resizing";
                    }
                    tempZapped.GetComponent<SpawnField>().switchMode();
                }

                if (tempZapped.name == "DeleteButton")
                {
                    if (boxExists)
                    {
                        Destroy(GameObject.Find("Pivot(Clone)"));
                        Destroy(GameObject.Find("newRoid"));
                        boxExists = false;
                        foreach(GameObject point in tagMaster.GetComponent<textParser>().objectList)
                        {
                            if (point.GetComponent<ObjBehavior>().Selected)
                            {
                                point.GetComponent<ObjBehavior>().Toggle();
                            }
                        }
                    }
                    tempZapped.GetComponent<Image>().color = newGray;
                    sphereSearchButton.GetComponent<Image>().color = Color.white;
                    cubeSearchButton.GetComponent<Image>().color = Color.white;
                    switchModeButton.GetComponent<Image>().color = Color.white;
                    switchModeButton.GetComponentInChildren<Text>().text = "Resizing";
                    switchModeButton.GetComponent<SpawnField>().switchMode();
                }

                if(tempZapped.name == "ToggleModeButton")
                {
                    toggleMode = !toggleMode;

                    if(tempZapped.GetComponent<Image>().color == newGray)
                    {
                        tempZapped.GetComponent<Image>().color = Color.white;
                        tempZapped.GetComponentInChildren<Text>().text = "Toggle Mode";
                    }
                    else
                    {
                        tempZapped.GetComponent<Image>().color = newGray;
                        tempZapped.GetComponentInChildren<Text>().text = "Displace Mode";
                    }
                }

                if(tempZapped.GetComponent<PortableBehavior>() && !toggleMode)
                {
                    tempZapped.transform.SetParent(transform);
                }
            }
            
        }


        //this final clause takes care of things like the print, delete and numeric keypad buttons, as they are only meant to be grayed out
        //when the user lasers them, and upon releasing should return to being white, or releasing portable objects when put in a new location. 
        //as it stands, each individual item must be references when that happens, and there may be a better way to implement this function given enough time
        if ((OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && lineClone.gameObject.activeInHierarchy == true) || OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            lineClone.GetComponent<LineRenderer>().startColor = Color.red;
            if(printButton.activeInHierarchy && printButton.GetComponent<Image>().color != Color.white)
            {
                printButton.GetComponent<Image>().color = Color.white;
            }
            if (deleteButton.activeInHierarchy && deleteButton.GetComponent<Image>().color != Color.white)
            {
                deleteButton.GetComponent<Image>().color = Color.white;
            }

            foreach(GameObject numericButton in numericButtons)
            {
                if(numericButton.GetComponent<Image>().color != Color.white)
                {
                    numericButton.GetComponent<Image>().color = Color.white;
                }
            }

            if(billboard.transform.parent.name == "hand_left")
            {
                billboard.transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            if(mainText.transform.parent.transform.parent.name == "hand_left")
            {
                mainText.transform.parent.transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            if(GameObject.Find("SelectMenu").transform.parent.name == "hand_left")
            {
                GameObject.Find("SelectMenu").transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            if (GameObject.Find("QueryMenu") && GameObject.Find("QueryMenu").transform.parent.name == "hand_left")
            {
                GameObject.Find("QueryMenu").transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            if (GameObject.Find("LayerMenu") && GameObject.Find("LayerMenu").transform.parent.name == "hand_left")
            {
                GameObject.Find("LayerMenu").transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            if (GameObject.Find("FindMenu") && GameObject.Find("FindMenu").transform.parent.name == "hand_left")
            {
                GameObject.Find("FindMenu").transform.SetParent(GameObject.Find("VRPlayer").transform);
            }

            foreach (GameObject point in tagMaster.GetComponent<TagCreator>().objectList)
            {
                if(point.transform.parent.name == "hand_left")
                {
                    point.transform.SetParent(GameObject.Find("Plot").transform);
                }
            }

            foreach(GameObject userPoint in GameObject.Find("hand_right").GetComponent<SpawnUserPoint>().points)
            {
                if(userPoint.transform.parent != null)
                {
                    userPoint.transform.parent = null;
                }
            }
        }
    }
}
