using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * A basic class that allows the user to hide / show the main menu
 */

public class MenuVisibility : MonoBehaviour {

    //Required references
    public Canvas mainMenu;
    public Text mainText;

    void Start()
    {
        //assign the references correctly upon start
        mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
        mainText = GameObject.Find("MainText").GetComponent<Text>();

    }

    // Update is called once per frame, and we handle a single user input here
    void Update () {

        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (mainMenu.gameObject.activeInHierarchy)
            {
                mainMenu.gameObject.SetActive(false);
            }
            else
            {
                mainMenu.gameObject.SetActive(true);

                //reset the text just in case

                mainText.text = "Welcome!\nUse the left joystick to move around horizontally, and the right joystick to control your height and rotation. " +
                                "Hold the left grip to begin pointing at objects in the scene, and use the left trigger to zap something! Explore the buttons " +
                                "below to call up additional menus, and hide this panel anytime (or bring it back) with X. When you're satisfied with a selection " +
                                "you've made in the scene, hit Print Selection to output a list of the object names in a CSV file!";
            }
        }

	}
}
