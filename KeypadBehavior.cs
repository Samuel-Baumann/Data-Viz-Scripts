using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is attached to each of the numeric buttons on the findMenu canvas, and takes care of custom search behavior
 */

public class KeypadBehavior : MonoBehaviour {

    //Basic references + some default strings to save repetition
    public GameObject player;

    public GameObject tagMaster;

    public Text userText;
    public Text findMenuText;
    public string thisText;

    string start = "OBJECT  "; //note the double space!

    void Start()
    {
        //assign approriate references
        player = GameObject.Find("VRPlayer");
        userText = GameObject.Find("UserText").GetComponent<Text>();
        findMenuText = GameObject.Find("FindMenuText").GetComponent<Text>();
        tagMaster = GameObject.Find("tagMaster");
        findMenuText.text = "Use the keypad to name an object, then hit Search!\nCurrent number of objects in scene: " + tagMaster.GetComponent<textParser>().objectList.Count;
        thisText = GameObject.Find(transform.name).GetComponent<Button>().GetComponentInChildren<Text>().text;
    }

    //Update is called once every frame, and here we ensure their tags are all numeric, similar to the toggleButton issue
    void Update()
    {
        if(tag != "numeric")
        {
            tag = "numeric";
        }
    }

    //This method is the main method in the class, and can be called from outside sources. Similar to Zapper, we check each object by name, and act accordingly by modifying text or sending a search request to VRMovement
    public void act()
    {
        if (gameObject.name == "AlphaClear")
        {
            userText.text = start;
            findMenuText.text = "Use the keypad to name an object, then hit Search!\nCurrent number of objects in scene: "+ tagMaster.GetComponent<textParser>().objectList.Count;
        }
        else if (gameObject.name == "AlphaBack" && userText.text.Length > 7)
        {
            userText.text = userText.text.Substring(0, userText.text.Length - 1);
        }
        else if(gameObject.name == "AlphaSearch")
        {
            findMenuText.text = "Locating " + userText.text + "...";

            if (GameObject.Find(userText.text))
            {
                if (!GameObject.Find(userText.text).GetComponent<ObjBehavior>().Selected)
                {
                    GameObject.Find(userText.text).GetComponent<ObjBehavior>().Toggle();
                }
                player.GetComponent<VRMovement>().relocate(GameObject.Find(userText.text).transform.position);
                findMenuText.text += "\n\nProperties: \n\nPosition - " + GameObject.Find(userText.text).transform.position.ToString() + "\nLayer - " + GameObject.Find(userText.text).GetComponent<ObjBehavior>().psuedoTag + "\nBONUS - TBD";
            }
            else
            {
                findMenuText.text += "\n\nError: No object with that name exists in the scene!";
            }
        }
        else
        {
            userText.text += thisText;
        }
    }
}
