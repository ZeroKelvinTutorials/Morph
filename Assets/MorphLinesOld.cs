using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphLinesOld : MonoBehaviour
{

    public LineRenderer[] shapes;
    public float morphTime;
    public List<Vector3> starting;
    public List<Vector3> ending;
    public List<int> listint = new List<int>();
    public List<Vector3> currentVector3s = new List<Vector3>();
    void MorphToWrapper(int index)
    {
        Debug.Log("Lets start morphing " + index);
        StopAllCoroutines();
        StartCoroutine(MorphTo(index, morphTime));
    }

    IEnumerator MorphTo(int index, float time)
    {
        float timer = 0;
        List<Vector3> startingPoints = GetPoints(this.GetComponent<LineRenderer>());
        List<Vector3> finishingPoints = GetPoints(shapes[index]);
        // starting = startingPoints;
        // ending = finishingPoints;
        int difference = startingPoints.Count - finishingPoints.Count;

        if(difference > 0)
        {
            finishingPoints = AddFillerPoints(finishingPoints, difference);
        }
        else if(difference < 0)
        {
            startingPoints = AddFillerPoints(startingPoints, -difference);
        }
        // starting = startingPoints;
        // ending = finishingPoints;
        LineRenderer myLineRenderer = this.GetComponent<LineRenderer>();
        myLineRenderer.positionCount = finishingPoints.Count;
        while(timer<time)
        {
            timer += Time.deltaTime;
            float percentage = timer/time;
            myLineRenderer.SetPositions(CalculatePositions(startingPoints, finishingPoints,percentage));
            yield return null;
        }

        myLineRenderer.SetPositions(finishingPoints.ToArray());
        yield return null;
    }
    //LineRendererLerp
    Vector3[] CalculatePositions(List<Vector3> points1 ,List<Vector3> points2, float progress)
    {
        List<Vector3> newPoints = new List<Vector3>();
        
        for(int i = 0; i<points1.Count; i++)
        {
            // pointsDebug.Log("Adding point " + i);
            points1[i] = Vector3.Lerp(points1[i],points2[i],progress);
            // newPoints.Add(newPoint);
        }

        return points1.ToArray();
    }
    
    List<Vector3> GetPoints(LineRenderer lineRenderer)
    {
        Vector3[] points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);
        List<Vector3> pointsList = new List<Vector3>(points);
        return pointsList;
    }
    List<Vector3> AddFillerPoints(List<Vector3> points, int amount)
    {
        List<Vector3> originalPoints = new List<Vector3>(points);
        currentVector3s = points;
        if(points.Count==0)
        {
            points.Add(Vector3.zero);
        }
        
        int sectionsAmount = points.Count-1;
        int pointsPerPoint = amount/sectionsAmount;
        int remainder = amount%sectionsAmount;
        int addedPoints = 0;
        for(int i = 0; i<sectionsAmount ; i ++)
        {
            int pointsToAdd = pointsPerPoint;
            if(remainder>i)
            {
                pointsToAdd++;
            }
            float percentagePerStep = (float)1/(pointsToAdd+1);
            for(int j = 0; j<pointsToAdd; j++)
            {
                float currentPercentage = percentagePerStep*j;
                points.Insert(i+j+1+addedPoints, Vector3.Lerp(originalPoints[i],originalPoints[i+1],currentPercentage));
            }
            addedPoints += pointsToAdd;
        }
        //method 1, weak. makes it not visually nice.

        // Vector3 lastPoint = points[points.Count-1];
        // for(int i = 0; i<amount; i++)
        // {
        //     points.Add(lastPoint);
        // }

        //method2, repeat (THIS MAKES FACE)

        // int pointAmount = points.Count;
        // int maxAmount = pointAmount+amount;

        // int currentIndex = 0;
        // int maxIndex = maxAmount-2;
        // int cycles = 0;
        // for(int i = 0; i < amount ; i++)
        // {
        //     // Debug.Log("Current index " + currentIndex + ". list length " + points.Count);
        //     points.Insert(currentIndex+(cycles*currentIndex), originalPoints[currentIndex]);
        //     Debug.Log(GetNextIndex(currentIndex,pointAmount-1));
        //     currentIndex = GetNextIndex(currentIndex,pointAmount-1);
        //     if(currentIndex == 0)
        //     {
        //         cycles++;
        //     }
        // }

        //method 2, repeat non staggered

        // int pointAmount = points.Count;
        // int maxAmount = pointAmount+amount;

        // int currentIndex = 0;
        // int maxIndex = maxAmount-2;
        // int cycles = 0;
        // for(int i = 0; i < amount ; i++)
        // {
        //     // Debug.Log("Current index " + currentIndex + ". list length " + points.Count);
        //     points.Insert(currentIndex+(cycles*currentIndex), originalPoints[currentIndex]);
        //     Debug.Log(GetNextIndexNonStaggered(currentIndex,pointAmount-1));
        //     currentIndex = GetNextIndexNonStaggered(currentIndex,pointAmount-1);
        //     if(currentIndex == 0)
        //     {
        //         cycles++;
        //     }
        // }


        //method3, fill



        // for(int i = 0; i < amount ; i++)
        // {
        //     // Debug.Log("Current index " + currentIndex + ". list length " + points.Count);



        //     points.Insert(currentIndex+(cycles*currentIndex), originalPoints[currentIndex]);

        //     Debug.Log(GetNextIndex(currentIndex,pointAmount-1));
        //     currentIndex = GetNextIndex(currentIndex,pointAmount-1);

        // }

        Debug.Log(originalPoints.Count + amount);
        Debug.Log(points.Count);
        return points;
    }
    int GetNextIndexNonStaggered(int previous, int max)
    {
        Debug.Log(previous + " " + max);
        if(previous==max)
        {
            Debug.Log("previous and max same");
            return 0;
        }
        else return previous++;
    }
    int GetNextIndex(int previous, int max)
    {
        float half = (float)max/2;
        if(previous < half)
        {
            return max-previous;
        }
        else if(previous > half)
        {
            if(previous-half < 1)
            {
                return 0;
            }
            return max-previous+1;
        }
        else if(previous == half)
        {
            return 0;
        }
        else{
            return 0;
        }
    }
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     MorphToWrapper(0);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     MorphToWrapper(1);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     MorphToWrapper(2);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     MorphToWrapper(3);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha5))
        // {
        //     MorphToWrapper(4);
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha6))
        // {
        //     MorphToWrapper(5);

        //     KeyCode.Numlock
        // }


        for(int i=0;i<10;i++)
         {
             if(Input.GetKeyDown((KeyCode)(48+i)))
             {
                 MorphToWrapper(i);
             }
         }
    }
}
