using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The counterpart to VRMovement, this class is only active when the user is locked in place, and allows for control over the searchField
 */

public class QBoxResize : MonoBehaviour {

    //references to necessary objects to keep track of lock state and search field position
    public GameObject player;
    public GameObject centroid;
    public bool moving = false;

    void Start()
    {
        //find references
        player = GameObject.Find("VRPlayer");
        centroid = GameObject.Find("newRoid");
    }

    //Update is called once every frame, and we handle all user input here
    void Update()
    {
        //must be locked
        if (player.GetComponent<VRMovement>().locked)
        {
            //either move the field around the scene by translating...
            if (moving)
            {
                if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0)
                {
                    transform.Translate(0, 2 * Time.deltaTime, 0);
                    centroid.transform.Translate(0, 2 * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.E) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0)
                {
                    transform.Translate(0, -2 * Time.deltaTime, 0);
                    centroid.transform.Translate(0, -2 * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.W) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0)
                {
                    transform.Translate(0, 0, 2 * Time.deltaTime);
                    centroid.transform.Translate(0, 0, 2 * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") < 0)
                {
                    transform.Translate(0, 0, -2 * Time.deltaTime);
                    centroid.transform.Translate(0, 0, -2 * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") > 0)
                {
                    transform.Translate(2 * Time.deltaTime, 0, 0);
                    centroid.transform.Translate(2 * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.A) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") < 0)
                {
                    transform.Translate(-2 * Time.deltaTime, 0, 0);
                    centroid.transform.Translate(-2 * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                //...or resize it by modifying the scale (we can also ensure that it cannot be negative, as colliders may have unexpected behavior, but Unity usually catches this.
                if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0)
                {
                    transform.localScale += new Vector3(0, 0.06f, 0);
                    centroid.transform.Translate(0, 0.03f, 0);
                }
                if (Input.GetKey(KeyCode.E) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0 /*&& transform.localScale.y > 0*/)
                {
                    transform.localScale -= new Vector3(0, 0.06f, 0);
                    centroid.transform.Translate(0, -0.03f, 0);
                }
                if (Input.GetKey(KeyCode.W) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0)
                {
                    transform.localScale += new Vector3(0, 0, 0.06f);
                    centroid.transform.Translate(0, 0, 0.03f);
                }
                if (Input.GetKey(KeyCode.S) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") < 0 /*&& transform.localScale.z > 0*/)
                {
                    transform.localScale -= new Vector3(0, 0, 0.06f);
                    centroid.transform.Translate(0, 0, -0.03f);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") > 0)
                {
                    transform.localScale += new Vector3(0.06f, 0, 0);
                    centroid.transform.Translate(0.03f, 0, 0);
                }
                if (Input.GetKey(KeyCode.A) || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") < 0 /*&& transform.localScale.x > 0*/)
                {
                    transform.localScale -= new Vector3(0.06f, 0, 0);
                    centroid.transform.Translate(-0.03f, 0, 0);
                }
            }
        }
    }
}
