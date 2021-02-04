using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A work in progress, this script will eventually turn into the convex hull creator, allowing a user to customize and move points around in a scene
 * to morph a complex shape as a search field instead of just a flexible cube or sphere. As of version 2.1(March 2019) it simply keeps track of necessary
 * data such as max/min coordinates, but expect modification in future, along with better documentation upon completion.
 * 
 * Update April 2019: Basic understanding of Mesh generation and triangles in Unity resulted in the last 3 methods below
 */

public class SpawnUserPoint : MonoBehaviour {

    public GameObject pointReference;
    public GameObject tempPoint;
    public List<GameObject> points;

    public float maxX, maxY, maxZ, minX, minY, minZ;

    public GameObject lineReference;
    public GameObject lineEdge;

    public GameObject hullHold;

    Vector3[] mVerts;
    Vector2[] newUVs;
    int[] mTris;

    void Start()
    {
        pointReference = (GameObject)Resources.Load("Prefabs/Centroid");
        points = new List<GameObject>();
    }

	void Update () {

        //create user point when button is pressed

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            tempPoint = Instantiate(pointReference);
            tempPoint.AddComponent<PortableBehavior>();
            tempPoint.transform.position = transform.position;
            tempPoint.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            tempPoint.name = "userPoint" + (points.Count + 1);
            points.Add(tempPoint);

            if(points.Count == 1)
            {
                maxX = tempPoint.transform.position.x;
                maxY = tempPoint.transform.position.y;
                maxZ = tempPoint.transform.position.z;
                minX = tempPoint.transform.position.x;
                minY = tempPoint.transform.position.y;
                minZ = tempPoint.transform.position.z;
            }
        }

        //continuously check the list for the max and min x y and z values

        foreach (GameObject point in points)
        {
            if (point.transform.position.x > maxX)
            {
                maxX = point.transform.position.x;
            }
            if (point.transform.position.y > maxY)
            {
                maxY = point.transform.position.y;
            }
            if (point.transform.position.z > maxZ)
            {
                maxZ = point.transform.position.z;
            }
            if (point.transform.position.x < minX)
            {
                minX = point.transform.position.x;
            }
            if (point.transform.position.y < minY)
            {
                minY = point.transform.position.y;
            }
            if (point.transform.position.z < minZ)
            {
                minZ = point.transform.position.z;
            }

        }

        //clear the points

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            foreach(GameObject point in points)
            {
                Destroy(point);
            }
            points = new List<GameObject>();
            Destroy(GameObject.Find("hullHold"));
        }

        //repeatedly drawing and destroying hullHold allows for the elastic feel of moving points around and having the shapes follow, but results in an undesirable flicker.
        //temp solution could involve boolean to stop this from happening once displaceMode is off, but in general a better implementation is advised.
        Destroy(GameObject.Find("hullHold"));

        if (points.Count > 3)
        {
            drawHull();
        }
    }


    //April Update: draing triangles between points instead of lines using UVs and mesh vertices. 

    void drawTriangle(Vector3 one, Vector3 two, Vector3 three)
    {
        GameObject newEmpty = new GameObject();
        newEmpty.transform.SetParent(GameObject.Find("hullHold").transform);
        newEmpty.AddComponent<MeshFilter>();
        newEmpty.AddComponent<MeshRenderer>();
        newEmpty.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Image&Mats/Materials/Translucent");

        mVerts = new Vector3[3];
        newUVs = new Vector2[3];
        mTris = new int[3];

        Mesh mesh = new Mesh();
        newEmpty.GetComponent<MeshFilter>().mesh = mesh;

        mVerts[0] = one;
        mVerts[1] = two;
        mVerts[2] = three;
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

    //necessary as we dont know which direction the face should be

    void drawDoubleSided(Vector3 one, Vector3 two, Vector3 three)
    {
        drawTriangle(one, two, three);
        drawTriangle(three, two, one);
    }

    //Primitive and incomplete method to draw triangluar faces between each unique set of points.
    //Delete/rework upon discovering a better solution

    void drawHull()
    {
        if (!GameObject.Find("hullHold"))
        {
            hullHold = new GameObject();
            hullHold.name = "hullHold";
        }

        foreach(GameObject point in points)
        {
            for (int i = points.IndexOf(point); i < points.Count - 2; i++)
            {
                //TO BE IMPROVED - this method of iteration does not cover a sufficient amount of triangles, not are they double-sided, resulting in odd, meaningless shapes being created with no collision.
                lineEdge = Instantiate(lineReference);
                lineEdge.name = "Triangle" + i;
                lineEdge.GetComponent<LineRenderer>().startColor = Color.black;
                lineEdge.GetComponent<LineRenderer>().endColor = Color.black;
                lineEdge.GetComponent<LineRenderer>().positionCount = 3;
                lineEdge.GetComponent<LineRenderer>().SetPosition(0, points[points.IndexOf(point)].transform.position);
                lineEdge.GetComponent<LineRenderer>().SetPosition(1, points[i + 1].transform.position);
                lineEdge.GetComponent<LineRenderer>().SetPosition(2, points[i + 2].transform.position);
                lineEdge.GetComponent<LineRenderer>().loop = true;
                lineEdge.SetActive(true);
                lineEdge.transform.SetParent(hullHold.transform);
                
                drawDoubleSided(points[points.IndexOf(point)].transform.position, points[i+1].transform.position, points[i+2].transform.position);
            }
        }
    }
}
