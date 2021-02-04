using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
 *A minor class that takes care of sorting and recoring all points inside a given search field (cubic or spherical).
 */

public class InsideTracker : MonoBehaviour {

    //The list in question
    public List<GameObject> insideList;

    void Start()
    {
        //initialize
        insideList = new List<GameObject>();
    }

    //The following methods require a rigidbody component to register collision, and the objects must also have some form of box collider. In this case, we use triggers, which register collisions
    //but do not physically inhibit movement, allowing fields, points and menu objects to pass through each other but retain information about their contact

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjBehavior>() && other.gameObject.activeInHierarchy)
        {
            if (!insideList.Contains(other.gameObject))
            {
                insideList.Add(other.gameObject);
                insideList = insideList.OrderBy(GameObject => GameObject.name).ToList();

                if (!other.GetComponent<ObjBehavior>().Selected)
                {
                    other.GetComponent<ObjBehavior>().Toggle();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ObjBehavior>())
        {
            if (insideList.Contains(other.gameObject) && other.gameObject.activeInHierarchy)
            {
                insideList.Remove(other.gameObject);
                insideList = insideList.OrderBy(GameObject => GameObject.name).ToList();

                if (other.GetComponent<ObjBehavior>().Selected)
                {
                    other.GetComponent<ObjBehavior>().Toggle();
                }
            }
        }
    }
}
