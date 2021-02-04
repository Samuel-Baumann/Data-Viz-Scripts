using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * A rudimentary version of zapper to be used in the start screen. It retains similar functionality, but cuts away needless superfluous references to work only in the first scene.
 * Likely to be removed if the start screen is deemed to be uneeded.
 */

public class ZapperBasic : MonoBehaviour
{
    public AudioClip zap;
    public AudioSource head;

    //for spawning the laser itself
    public GameObject lineReference;
    public LineRenderer lineClone;
    public float range = 100f;

    //the object we hit
    public GameObject tempZapped;


    //Start will simply locate all needed objects in the scene, avoiding tedious clicking and dragging to assign references by hand.
    //It can also make sure objects that are suppsed to be invisible start invisible!
    void Start()
    {
        lineClone = Instantiate(lineReference.GetComponent<LineRenderer>());
        lineClone.transform.SetParent(transform);
        lineClone.transform.position = transform.position + new Vector3(-0.03f, 0, 0);

        lineClone.gameObject.SetActive(false);
        lineClone.startColor = Color.red;

        head = GameObject.FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame, and is where all user input is handled.
    void Update()
    {

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
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && lineClone.gameObject.activeInHierarchy == true)
        {
            lineClone.startColor = Color.white;
            RaycastHit hitInfo;

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
            {
                tempZapped = GameObject.Find(hitInfo.transform.name);
                Debug.Log(tempZapped.name);

                //change scale of line if possible to make it more immersive? In progress
                //lineClone.transform.localScale = new Vector3(lineClone.transform.localScale.x, lineClone.transform.localScale.y, Vector3.Distance(transform.position, tempZapped.transform.position));

                //The following if statements are self evident: if we hit X, do Y behavior
                if(tempZapped.name == "Exit Button")
                {
                    Application.Quit();
                }
                else //hit a button to navigate to a different scene, load into it by name
                {
                    //head.PlayOneShot(zap, 1); maybe audio in future?
                    SceneManager.LoadScene(tempZapped.name);
                }
            }
        }

    }
}
