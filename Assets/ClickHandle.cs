using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandle : MonoBehaviour
{
    public Transform otherObject; 
    public ArrowPlacer arrowPlacer; 

    void OnMouseDown()
    {
        if (otherObject != null && arrowPlacer != null)
        {
            arrowPlacer.startPoint = transform;
            arrowPlacer.endPoint = otherObject;

        }
    }
}
