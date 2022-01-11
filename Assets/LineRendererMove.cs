using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            LineRenderer line = this.GetComponent<LineRenderer>();
            Vector3[] points = new Vector3[line.positionCount];
            line.GetPositions(points);
            List<Vector3> newPoints = new List<Vector3>(points);
            for(int i = 0; i < newPoints.Count; i++)
            {
                points[i] = points[i] + Vector3.up*.1f;
            }
            line.SetPositions(points);
        }
    }
}
