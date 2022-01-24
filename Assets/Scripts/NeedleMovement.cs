using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{
    private Touch touch;

    private RaycastHit hit;

    private bool elinde;
    public LayerMask layerMask;
    private BoxCollider _collider;
    public float zPos;
    
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        transform.TransformPoint(_collider.bounds.center);
        zPos = transform.position.z;
    }

    
    void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            Ray pos = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(pos,out hit,Mathf.Infinity,layerMask) && (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved))
            {
                transform.position = new Vector3(hit.point.x,hit.point.y,zPos+0.7f);
            }
            else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            }
        }

      
    }
    
}
