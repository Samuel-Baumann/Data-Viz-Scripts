using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * A small class responsible for making toggleButtons based on how many layers the user specified in the appropriate .txt file
 */

public class ToggleMaker : MonoBehaviour {

    //reference variables to keep track of the original toggle, the toggle to create and a list of all toggles
    public Toggle togglePrefab;
    public Toggle tempReference;

    public List<Toggle> toggleList;

    public void createToggle(string name, int index)
    {
        //create the button based on the layer, name it and stagger its position
        tempReference = Instantiate(togglePrefab);
        toggleList.Add(tempReference);
        tempReference.gameObject.transform.SetParent(transform);
        tempReference.name = name;
        tempReference.GetComponentInChildren<Text>().text = name;
        tempReference.transform.position = transform.position + new Vector3(0, 0.8f, 0);
        tempReference.transform.Rotate(0, -60, 0);

        tempReference.transform.position -= new Vector3(0, index * 0.2f, 0);
    }

    //Bug: if the tag is specified in createToggle, their tags are equal to the user specified tags instead. This little update fixes that by continuously polling for that change, but is slightly ineffecient
    void Update()
    {
        if(toggleList.Count > 0)
        {
            foreach(Toggle toggle in toggleList)
            {
                if(toggle.tag != "toggleButton")
                {
                    toggle.tag = "toggleButton";
                }
            }
        }
    }
}
