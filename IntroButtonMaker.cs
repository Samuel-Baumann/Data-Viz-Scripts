using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroButtonMaker : MonoBehaviour {

    //A small script similar to toggle maker that dynamically creates buttons based on how many scenes are built in the project.
    //This script will likely be removed or remodeled entirely if a better implementation is discovered, as it uses needlessly 
    //complicated features like the SceneUtility() methods.

    public Button navigButton;
    public Button tempButton;

	// Use this for initialization
	void Start () {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            tempButton = Instantiate(navigButton);
            tempButton.transform.SetParent(transform);
            tempButton.transform.position = transform.position - new Vector3(0, i * 0.5f, 0);
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            tempButton.name = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1); ;
            tempButton.GetComponentInChildren<Text>().text = tempButton.name;
        }
	}
	
}
