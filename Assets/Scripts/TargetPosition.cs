using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{


    Vector3 targetPosition;
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {

       
        if (Input.GetMouseButtonDown(0))
        {
            getTargetTransform();
        }

    }

    void getTargetTransform()
    {      
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
            transform.position = targetPosition;
        }    
    }
}
