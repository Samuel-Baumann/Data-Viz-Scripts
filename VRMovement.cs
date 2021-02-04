using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The backbone of the program in charge of moving the player around the scene and
 * relocating to a given object's coordinates. Modify lookAt() method post relocate(),
 * as currently the player's rotation is locked as long as their position is exactly equal
 * to the seachObject's position. Minor but noticeable.
*/

public class VRMovement : MonoBehaviour {

    //instance variables for speed, rotation and input, plus some booleans to see if we're searching / looking at a target point
    public float moveSpd;
    Vector2 dirInput;

    public bool locked = false;
    public bool relocating = false;

    public Vector3 target;
    public Vector3 offset = new Vector3(0, 0, -3);

    private float damping = 10;
    public float rotSpeed = 300;

    Quaternion desiredTurn;

    void Start()
    {
        moveSpd = 5.0f;
    }

    //Update is called once every frame, and we handle all user input here
    void Update()
    {
        //ability to lock or unlock movement, allowing for control of the search field with the joysticsk instead
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            locked = !locked;
        }

        if (locked)
        {
            //do nothing
        }
        else
        {
            //Most of the controls for movement were found online and modified to work with VR, but you can easily apply forces to objects with rigidbodies instead of translating should you feel it necessary
            dirInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            dirInput = Vector2.ClampMagnitude(dirInput, 1);
            dirInput *= Time.deltaTime;
            dirInput *= moveSpd;

            transform.Translate(dirInput.x, 0, dirInput.y);

            if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0)
            {
                transform.Translate(0, 1 * Time.deltaTime * moveSpd, 0);
            }
            if (Input.GetKey(KeyCode.E) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0)
            {
                transform.Translate(0, -1 * Time.deltaTime * moveSpd, 0);
            }

            var desiredRot = transform.eulerAngles.y;

            if (Input.GetKey(KeyCode.C) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") > 0)
            {
                desiredRot += rotSpeed * Time.deltaTime;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z), Time.deltaTime * damping);
            }
            if (Input.GetKey(KeyCode.Z) || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") < 0)
            {
                desiredRot -= rotSpeed * Time.deltaTime;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z), Time.deltaTime * damping);
            }
        }

        //Check to see if we have a target location we want to go, and if so, move there incrementally
        if (relocating)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpd * Time.deltaTime);
            if ((target - transform.position) != Vector3.zero)
            {

            }
            else
            {
                desiredTurn = Quaternion.LookRotation(target - transform.position);
            }
           
        }

        //this line forces the player to look at the object at all times unless they move, and may be revised if time allows
        if (transform.position == target)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredTurn, moveSpd * Time.deltaTime);
            relocating = false;
        }


    }

    //a method allowing outside sources to toggle 'relocating' and passing in a target
    public void relocate(Vector3 position)
    {
        target = position + offset;
        relocating = true;
    }
}
