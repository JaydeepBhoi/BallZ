using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLine : MonoBehaviour
{
   public LineRenderer lineRenderer;

    Vector3 dragStartPoint;

    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();

        lineRenderer.enabled = false;
    }


    public void startPoints(Vector3 worldPos) {

        
        dragStartPoint = worldPos;
        dragStartPoint = new Vector3(dragStartPoint.x, -4.67f, dragStartPoint.z);
        //Debug.Log("the value of y"+dragStartPoint.y);
        //Debug.Log(worldPos.y);
        //-4.67
        
        lineRenderer.SetPosition(0, dragStartPoint);

    }

    public void endPoints(Vector3 worldPos)
    {
        Vector3 finalPoint = worldPos - dragStartPoint;
        Vector3 endsPoint = transform.position + finalPoint;

        lineRenderer.SetPosition(1, endsPoint);
    }
}
