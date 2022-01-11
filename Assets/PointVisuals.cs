using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointVisuals : MonoBehaviour
{
    LineRenderer myLine;
    int pointCounter = 0;
    List<GameObject> points = new List<GameObject>();
    void OnEnable()
    {
        myLine = this.GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        CreatePoints();
    }
    void CreatePoints()
    {
        for(int i = 0; i < myLine.positionCount; i++)
        {
            if(i>=pointCounter)
            {
                GameObject newDot = Instantiate(Resources.Load("VisualizeDot") as GameObject, myLine.GetPosition(i), Quaternion.identity);
                newDot.transform.parent = this.transform;
                pointCounter++;
                points.Add(newDot);
            }
            else
            {
                points[i].transform.position = myLine.GetPosition(i);
            }
            
        }
    }
}
