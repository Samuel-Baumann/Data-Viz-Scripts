using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class textParser : MonoBehaviour {

    //This class was introduced as part of the April 2019 update, and borrows from the XRproject's DBVI parser scripts by Luc Belliveau.
    //Those scripts are available in the XR project worked on by Jean-Francois and Peter Nguyen, but the TagCreator script has been left in as a reference
    //To explain the basic parsing techniques used.

    //Needed prefabs, references and paths
    public List<GameObject> objectList;
    public GameObject pointPrefab;
    GameObject tempReference;

    string path;
    string line;
    public int numTags;
    public int numVecFields;
    public int numLinkedSets;

    public List<string> tags;
    public List<Color32> colors;

    public LineRenderer axisPrefab;
    public LineRenderer Xaxis, Yaxis, Zaxis;

    public float maxX, maxY, maxZ, minX, minY, minZ;

    public float minSize, maxSize;

    public GameObject layerPanel;

    public GameObject unitArrowPrefab;
    public GameObject tempArrowRef;
    public List<GameObject> arrows;

    public List<GameObject> triangles;
    public int hullCount = 0;
    public int lineCount = 0;
    public int faces;
    Vector3[] mVerts;
    Vector2[] newUVs;
    int[] mTris;

    public List<GameObject> lineLinks;

    public GameObject billBoard;
    public GameObject billBoardToggle;

    void Start()
    {
        if (GameObject.Find("Plot"))
        {
            Destroy(GameObject.Find("Plot"));
            Destroy(GameObject.Find("Xaxis"));
            Destroy(GameObject.Find("Yaxis"));
            Destroy(GameObject.Find("Zaxis"));
        }
        if (GameObject.Find("arrows"))
        {
            Destroy(GameObject.Find("arrows"));
        }
        if (GameObject.Find("triangles"))
        {
            Destroy(GameObject.Find("triangles"));
        }
        if (GameObject.Find("linkedSets"))
        {
            Destroy(GameObject.Find("linkedSets"));
        }

        GameObject plot = new GameObject();
        plot.name = "Plot";
        GameObject arrows = new GameObject();
        arrows.name = "arrows";
        GameObject triangles = new GameObject();
        triangles.name = "triangles";
        GameObject linkedSets = new GameObject();
        linkedSets.name = "linkedSets";

        //note that you can manually assign the path to a string, but application.datapath is used to access that information post build
        //These lines must be modified if new text files are created and expected to be read!

        path = Application.dataPath + "/Resources/TextFiles/unity-DBVI-data.txt";
      
        objectList = new List<GameObject>();
        colors = new List<Color32>();
        tags = new List<string>();

        StreamReader reader = new StreamReader(path, Encoding.Default);

        using (reader)
        {
            do
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    string[] statements = Regex.Split(line, @"\s+");

                    if (line.StartsWith("NUMBER_OF_CLASSES"))
                    {
                        numTags = int.Parse(statements[1]);
                    }
                    if (line.StartsWith("NUMBER_OF_VECTORFIELDS"))
                    {
                        numVecFields = int.Parse(statements[1]);
                    }
                    if (line.StartsWith("NUMBER_OF_LINKED_SETS"))
                    {
                        numLinkedSets = int.Parse(statements[1]);
                    }
                    if (line.StartsWith("BILLBOARD_IMAGE"))
                    {
                        if(statements.Length > 1)
                        {
                            billBoard.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Image&Mats/Materials/" + statements[1]);
                            if(billBoard.GetComponent<MeshRenderer>().material == null)
                            {
                                Debug.Log("Error: no Image with that name found in assets! Please add it manually, or check the name");
                            }
                        }
                        else
                        {
                            billBoardToggle.SetActive(false);
                        }
                    }
                    if (line.StartsWith("MINIMUM_X"))
                    {
                        minX = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MAXIMUM_X"))
                    {
                        maxX = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MINIMUM_Y"))
                    {
                        minY = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MAXIMUM_Y"))
                    {
                        maxY = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MINIMUM_Z"))
                    {
                        minZ = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MAXIMUM_Z"))
                    {
                        maxZ = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MINIMUM_OBJECT_SIZE"))
                    {
                        minSize = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("MAXIMUM_OBJECT_SIZE"))
                    {
                        maxSize = float.Parse(statements[1]);
                    }
                    if (line.StartsWith("CLASS_NAMES"))
                    {
                        for (int i = 0; i < numTags; i++)
                        {
                            string tagToAdd = reader.ReadLine();
                            tags.Add(tagToAdd);
                            layerPanel.GetComponent<ToggleMaker>().createToggle(tagToAdd, i);
                        }
                    }
                    if (line.StartsWith("CLASS_COLORS"))
                    {
                        for (int i = 0; i <= numTags; i++)
                        {
                            string[] RGBValues = Regex.Split(reader.ReadLine(), @"\s+");
                            if(RGBValues[0] != "#")
                            {
                                colors.Add(new Color32(byte.Parse(RGBValues[1]), byte.Parse(RGBValues[2]), byte.Parse(RGBValues[3]), 60));
                            }
                        }
                    }
                    if (line.StartsWith("OBJECT"))
                    {
                        tempReference = Instantiate(pointPrefab);
                        tempReference.transform.SetParent(plot.transform);
                        tempReference.AddComponent<ObjBehavior>();
                        tempReference.name = line;

                        for(int i = 0; i < 14; i++)
                        {
                            string objAttributes = reader.ReadLine();
                            if(i == 1)
                            {
                                string[] coords = Regex.Split(objAttributes, @"\s+");
                                tempReference.transform.position = new Vector3(float.Parse(coords[1]) - minX, float.Parse(coords[2]) - minY, float.Parse(coords[3]) - minZ);
                            }
                            if(i == 2)
                            {
                                string[] scale = Regex.Split(objAttributes, @"\s+");
                                tempReference.transform.localScale *= float.Parse(scale[1]);
                            }
                            if(i == 7)
                            {
                                string[] layer = Regex.Split(objAttributes, @"\s+");
                                tempReference.GetComponent<MeshRenderer>().material.color = colors[int.Parse(layer[1]) - 1];
                                tempReference.GetComponent<ObjBehavior>().psuedoTag = tags[int.Parse(layer[1]) - 1];
                            }
                        }

                        objectList.Add(tempReference);
                    }
                    
                    if(line.StartsWith("#CLASS_NAME"))
                    {
                        hullCount++;
                        GameObject wrapper = new GameObject();
                        wrapper.transform.SetParent(GameObject.Find("triangles").transform);
                        wrapper.name = "wrapper " + hullCount;
                        string temp = line;
                        temp = reader.ReadLine();


                        faces = int.Parse(Regex.Split(temp, @"\s+")[2]);
                        temp = reader.ReadLine(); //transparency here, TBD
                        for(int i = 0; i < faces; i++)
                        {
                            temp = reader.ReadLine();
                            string[] triangleCoords = Regex.Split(temp, @"\s+");
                            drawDoubleSided(int.Parse(triangleCoords[1]), int.Parse(triangleCoords[2]), int.Parse(triangleCoords[3]), hullCount);
                        }
                    }
                    if(line.StartsWith("# LINKED_OBJECTS FILE"))
                    {
                        string temp = line;
                        temp = reader.ReadLine();
                        lineCount++;
                        GameObject tempSet = new GameObject();
                        tempSet.name = "Linked Set " + lineCount;
                        tempSet.transform.SetParent(GameObject.Find("linkedSets").transform);

                        while(!temp.StartsWith("LINKED") && !temp.StartsWith("#-------"))
                        {
                            string[] lineCoords = Regex.Split(temp, @"\s+");
                            if (GetComponent<colorList>().validColorName(lineCoords[2]))
                            {
                                drawLine(int.Parse(lineCoords[0]), int.Parse(lineCoords[1]), GetComponent<colorList>().RGBtriples[0], GetComponent<colorList>().RGBtriples[1], GetComponent<colorList>().RGBtriples[2], lineCount);
                            }
                            else
                            {
                                drawLine(int.Parse(lineCoords[0]), int.Parse(lineCoords[1]), byte.Parse(lineCoords[2]), byte.Parse(lineCoords[3]), byte.Parse(lineCoords[4]), lineCount);
                            }
                            temp = reader.ReadLine();
                        }
                    }
                    if(line.StartsWith("# VECTORFIELD FILE"))
                    {
                        string temp = line;
                        temp = reader.ReadLine();

                        while(!temp.StartsWith("VECTORFIELD") && !temp.StartsWith("# END ----"))
                        {
                            string[] info = Regex.Split(temp, ",");
                            string[] objValues = Regex.Split(info[0], @"\s+");
                            List<string> names = new List<string>();
                            foreach(string objName in objValues)
                            {
                                names.Add("OBJECT  " + objName);
                            }
                            if (GetComponent<colorList>().validColorName(info[1]))
                            {
                                drawArrowList(names, GetComponent<colorList>().RGBtriples[0], GetComponent<colorList>().RGBtriples[1], GetComponent<colorList>().RGBtriples[2], float.Parse(info[2]), float.Parse(info[3]), float.Parse(info[4]), int.Parse(info[5]));
                            }
                            else
                            {
                                string[] RGBvalues = Regex.Split(info[1], @"s\+");
                                drawArrowList(names, byte.Parse(RGBvalues[0]), byte.Parse(RGBvalues[1]), byte.Parse(RGBvalues[2]), float.Parse(info[2]), float.Parse(info[3]), float.Parse(info[4]), int.Parse(info[4]));
                            }
                            temp = reader.ReadLine();
                        }
                    }
                }
            }

            while (line != null);

            reader.Close();

            for (int i = 0; i < numVecFields; i++)
            {
                layerPanel.GetComponent<ToggleMaker>().createToggle("Vectorfield " + (i+1), numTags + i);
            }

            for (int i = 0; i < numTags; i++)
            {
                layerPanel.GetComponent<ToggleMaker>().createToggle("wrapper " + (i + 1), numTags + numVecFields + i);
            }
            for (int i = 0; i < numLinkedSets; i++)
            {
                layerPanel.GetComponent<ToggleMaker>().createToggle("Linked Set " + (i + 1), numTags + + numTags + numVecFields + i);
            }
        }
        
        //spawn in axes
        Xaxis = Instantiate(axisPrefab);
        Xaxis.startColor = Color.black;
        Xaxis.name = "Xaxis";
        Xaxis.SetPosition(0, new Vector3(0, 0, 0));
        Xaxis.SetPosition(1, new Vector3(maxX - minX, 0, 0));
        Xaxis.gameObject.SetActive(true);

        Yaxis = Instantiate(axisPrefab);
        Yaxis.startColor = Color.black;
        Yaxis.name = "Yaxis";
        Yaxis.SetPosition(0, new Vector3(0, 0, 0));
        Yaxis.SetPosition(1, new Vector3(0, maxY - minY, 0));
        Yaxis.gameObject.SetActive(true);

        Zaxis = Instantiate(axisPrefab);
        Zaxis.startColor = Color.black;
        Zaxis.name = "Zaxis";
        Zaxis.SetPosition(0, new Vector3(0, 0, 0));
        Zaxis.SetPosition(1, new Vector3(0, 0, maxZ - minZ));
        Zaxis.gameObject.SetActive(true);

        for(int i = 0; i < arrows.transform.childCount; i++)
        {
            arrows.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < triangles.transform.childCount; i++)
        {
            triangles.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < linkedSets.transform.childCount; i++)
        {
            linkedSets.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < plot.transform.childCount; i++)
        {
            plot.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    int locateInList(List<string> list, string target)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == target)
            {
                return i;
            }
        }
        return 0; //get here if cant find index, which shouldnt be possible
    }

    void drawArrow(string start, string end, byte R, byte G, byte B, float transparency, float cylinderRad, float coneRad, int index)
    {
        tempArrowRef = Instantiate(unitArrowPrefab).gameObject;
        tempArrowRef.name = "Arrow: " + start + "-" + end;
        arrows.Add(tempArrowRef);
        tempArrowRef.transform.position = GameObject.Find(start).transform.position;
        tempArrowRef.transform.LookAt(GameObject.Find(end).transform.position);
        tempArrowRef.transform.localScale += new Vector3(0, 0, Vector3.Distance(GameObject.Find(start).transform.position, GameObject.Find(end).transform.position) - 1);
        tempArrowRef.GetComponent<LineRenderer>().startColor = new Color32(R, G, B, 255);
        tempArrowRef.GetComponent<LineRenderer>().endColor = new Color32(R, G, B, 255);
        tempArrowRef.GetComponent<arrowProperties>().vectorNumber = index;
        tempArrowRef.transform.SetParent(GameObject.Find("arrows").transform);
    }

    void drawArrowList(List<string> arrows, byte R, byte G, byte B, float transparency, float cylinderRad, float coneRad, int index)
    {
        for(int i = 0; i < arrows.Count-1; i++)
        {
            drawArrow(arrows[i], arrows[i + 1], R, G, B, transparency, cylinderRad, coneRad, index);
        }
    }

    void drawTriangle(int A, int B, int C, int hullCount)
    {
        GameObject newEmpty = new GameObject();
        newEmpty.name = "TRIANGLE " + A.ToString() + "-" + B.ToString() + "-" + C.ToString();
        newEmpty.transform.SetParent(GameObject.Find("wrapper " + hullCount).transform);
        newEmpty.AddComponent<MeshFilter>();
        newEmpty.AddComponent<MeshRenderer>();
        newEmpty.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Image&Mats/Materials/Translucent");
        newEmpty.GetComponent<MeshRenderer>().material.color = colors[hullCount-1];

        mVerts = new Vector3[3];
        newUVs = new Vector2[3];
        mTris = new int[3];

        Mesh mesh = new Mesh();
        newEmpty.GetComponent<MeshFilter>().mesh = mesh;

        mVerts[0] = GameObject.Find("OBJECT  " + A).transform.position;
        mVerts[1] = GameObject.Find("OBJECT  " + B).transform.position;
        mVerts[2] = GameObject.Find("OBJECT  " + C).transform.position;
        /*
        newUVs[0] = new Vector2(0, 0);
        newUVs[1] = new Vector2(0, 1);
        newUVs[2] = new Vector2(1, 0);
        */
        mTris[0] = 0;
        mTris[1] = 1;
        mTris[2] = 2;

        mesh.vertices = mVerts;
        mesh.uv = newUVs;
        mesh.triangles = mTris;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    void drawDoubleSided(int A, int B, int C, int hullCount)
    {
        drawTriangle(A, B, C, hullCount);
        drawTriangle(C, B, A, hullCount);
    }

    void drawLine(int start, int end, byte R, byte G, byte B, int index)
    {
        LineRenderer tempLine = Instantiate(axisPrefab);
        tempLine.gameObject.SetActive(true);
        tempLine.name = "Link " + start.ToString() + "-" + end.ToString();
        tempLine.transform.SetParent(GameObject.Find("Linked Set " + index).transform);
        tempLine.startWidth = 0.02f;
        tempLine.endWidth = 0.02f;
        tempLine.startColor = new Color32(R, G, B, 255);
        tempLine.endColor = new Color32(R, G, B, 255);
        tempLine.SetPosition(0, GameObject.Find("OBJECT  " + start).transform.position);
        tempLine.SetPosition(1, GameObject.Find("OBJECT  " + end).transform.position);
    }
}
