using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

/*
 * The core of the project, this class is responsible for reading information from a properly formatted txt fileand instatiating points based on that file.
 * It also dynamically creates tags depending on how many the user specifies, can create the points as any shape so long as a prefab is provided in the Assets,
 * customize layer colors using RGB values, modify its size and position and instantiate necessary toggle buttons for each layer, all while modifying the underlying 
 * project on the go to add or remove elements using the Unity Editor. Should more information be needed, such as a point's Bonus info or other customizable properties,
 * add functionality to this script, and create new delimiters to recognize what information is being passed through!
 * 
 * April 2019 Update: textParse uses this class as a template and reads correct DBVI files rather than custom text files. As a result, this class is no longer needed and the script is
 * deactivated on tagMaster, but I have kept it in as a reference.
 */

public class TagCreator : MonoBehaviour {

    //Needed prefabs, references and paths
    public List<GameObject> objectList;
    public GameObject pointPrefab;
    GameObject tempReference;

    public List<GameObject> arrowList;
    public GameObject arrowPrefab;
    GameObject tempArrow;

    string path;
    string line;
    public int numTags;

    public GameObject layerPanel;

    public List<string> tags;
    public List<Color32> colors;

    public LineRenderer axisPrefab;
    public LineRenderer Xaxis, Yaxis, Zaxis;

    public float largestX, largestY, largestZ;

    // Use this for initialization
    void Start()
    {
        GameObject plot = new GameObject();
        plot.name = "Plot";

        //note that you can manually assign the path to a string, but application.datapath is used to access that information post build

        if (GameObject.Find("CancerSceneFlag"))
        {
            path = Application.dataPath + "/Resources/TextFiles/_CancerTags.txt";
        }
        else if (GameObject.Find("RadarSceneFlag"))
        {
            path = Application.dataPath + "/Resources/TextFiles/_RadarTags.txt";
        }
        else
        {
            path = Application.dataPath + "/Resources/TextFiles/_ExampleTags.txt";
        }

        objectList = new List<GameObject>();
        colors = new List<Color32>();
        tags = new List<string>();

        StreamReader reader = new StreamReader(path, Encoding.Default);

        using (reader)
        {
            do
            {
                line = reader.ReadLine();

                if (line != null && !(line.Substring(0, 1) == "/")) //line doesnt start with '/' (a comment indicator)
                {
                    if (line.Substring(0, 1) == "#") //line is a tag identifier, sort out tags and associated RGBs
                    {
                        string[] tagIDs = line.Split('|');

                        if (tagIDs.Length > 0)
                        {
                            numTags = int.Parse(tagIDs[1]);
                        }
                        for (int i = 0; i < tagIDs.Length - 2; i++)
                        {
                            string[] rgbValues = tagIDs[i + 2].Split(',');

                            tags.Add(rgbValues[0]);
                            colors.Add(new Color32(byte.Parse(rgbValues[1]), byte.Parse(rgbValues[2]), byte.Parse(rgbValues[3]), 255));
                            layerPanel.GetComponent<ToggleMaker>().createToggle(rgbValues[0], i);
                        }
                    }
                    else if(line.Substring(0, 1) == "*") //line is a shape identifier, add to here to load new shapes for points after making them a prefab
                    {
                        string[] shape = line.Split('|');

                        if(shape[1] == "Cube")
                        {
                            pointPrefab = (GameObject)Resources.Load("Prefabs/pointPrefabCube");
                        }
                        else
                        {
                            pointPrefab = (GameObject)Resources.Load("Prefabs/pointPrefab");
                        }
                    }
                    else if (line.Substring(0, 1) == ">") //line is an arrow identifier, draw arrow
                    {
                        string[] arrowPoints = line.Split('|');

                        //drawArrow(arrowPoints[1], arrowPoints[2]);
                    }
                    else //must be object, parse accordingly
                    {
                        string[] entries = line.Split('|'); //split line into data

                        if (entries.Length > 0)
                        {
                            //instantiate and modify position, scale, etc.
                            tempReference = Instantiate(pointPrefab);
                            tempReference.AddComponent<ObjBehavior>();
                            //tempReference.AddComponent<PortableBehavior>();
                            tempReference.transform.SetParent(plot.transform);
                            tempReference.name = entries[0];
                            tempReference.GetComponent<ObjBehavior>().psuedoTag = entries[1];

                            Vector3 location = new Vector3(float.Parse(entries[2]), float.Parse(entries[3]), float.Parse(entries[4]));
                            tempReference.transform.position = location;
                            tempReference.GetComponent<Renderer>().material.color = colors[locateInList(tags, entries[1])];
                            tempReference.transform.localScale *= float.Parse(entries[5]);
                            objectList.Add(tempReference);
                        }
                    }

                }


            }
            while (line != null);

            reader.Close();
        }

        largestX = objectList[0].transform.position.x;
        largestY = objectList[0].transform.position.y;
        largestZ = objectList[0].transform.position.z;

        foreach (GameObject point in objectList)
        {
            if(point.transform.position.x > largestX)
            {
                largestX = point.transform.position.x;
            }
            if (point.transform.position.y > largestY)
            {
                largestY = point.transform.position.y;
            }
            if (point.transform.position.z > largestZ)
            {
                largestZ = point.transform.position.z;
            }
        }

        //spawn in axes
        Xaxis = Instantiate(axisPrefab);
        Xaxis.startColor = Color.black;
        Xaxis.name = "Xaxis";
        Xaxis.SetPosition(0, new Vector3(0, 0, 0));
        Xaxis.SetPosition(1, new Vector3(largestX, 0, 0));
        Xaxis.gameObject.SetActive(true);

        Yaxis = Instantiate(axisPrefab);
        Yaxis.startColor = Color.black;
        Yaxis.name = "Yaxis";
        Yaxis.SetPosition(0, new Vector3(0, 0, 0));
        Yaxis.SetPosition(1, new Vector3(0, largestY, 0));
        Yaxis.gameObject.SetActive(true);

        Zaxis = Instantiate(axisPrefab);
        Zaxis.startColor = Color.black;
        Zaxis.name = "Zaxis";
        Zaxis.SetPosition(0, new Vector3(0, 0, 0));
        Zaxis.SetPosition(1, new Vector3(0, 0,largestZ));
        Zaxis.gameObject.SetActive(true);

        drawListofArrows(objectList, 255, 0, 0);
    }

    //this method was found on the internet, and is used for directly changing Unity's underlying assets. It is not useful post build, and a similar functionality (psuedotags) has replaced it 
    /*
    void createTag(string name)
    {
        // Open tag manager
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");

        // Adding a Tag
        string s = name;
        // First check if it is not already present
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(s)) { found = true; break; }
        }
        // if not found, add it
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
            n.stringValue = s;
        }
        tagManager.ApplyModifiedProperties();
    }
    */

    int locateInList(List<string> list, string target)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i] == target)
            {
                return i;
            }
        }
        return 0; //get here if cant find index, which shouldnt be possible
    }

    void drawArrow(string start, string end, byte R, byte G, byte B)
    {
        tempArrow = Instantiate(arrowPrefab).gameObject;
        tempArrow.name = "Arrow: " + start + "-" + end;
        arrowList.Add(tempArrow);
        //tempArrow.GetComponent<LineRenderer>().positionCount = 2;
        tempArrow.transform.position = GameObject.Find(start).transform.position;
        tempArrow.transform.LookAt(GameObject.Find(end).transform.position);
        tempArrow.transform.localScale += new Vector3(0, 0, Vector3.Distance(GameObject.Find(start).transform.position, GameObject.Find(end).transform.position)-1);
        tempArrow.GetComponent<LineRenderer>().startColor = new Color32(R, G, B, 255);
        tempArrow.GetComponent<LineRenderer>().endColor = new Color32(R, G, B, 255);
    }

    void drawListofArrows(List<GameObject> points, byte R, byte G, byte B)
    {
        for(int i = 0; i < points.Count - 1; i++)
        {
            drawArrow(points[i].name, points[i + 1].name, R, G, B);
        }
    }
}
