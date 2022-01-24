using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GreenHitCounter : MonoBehaviour
{
    public Transform[] boxes;
    private int closedGreenBoxed = 0;
    void Start()
    {
        boxes = new Transform[transform.childCount];
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (closedGreenBoxed < transform.childCount)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                closedGreenBoxed++;
                if (boxes[i].gameObject.activeSelf)
                {
                    closedGreenBoxed = 0;
                    break;
                }
            }
        }

    }

    public int ClosedBoxed => closedGreenBoxed;
    
}
