using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private Vector3 sag, sol;
    private bool sagda = false, solda = false;
    public bool hareketEdilecek = false;
    
    void Start()
    {
      
        sag = new Vector3(1, 0, 0);
        sol = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hareketEdilecek)
        {
            shake();
            
        }
    }

    void shake()
    {
        if (!sagda && !solda)
        {
            SagaGit();
            if (transform.position.x > 0.2f)
            {
                sagda = true;
                solda = false;

            }
        }

        if (!solda && sagda)
        {
            solaGit();
            if (transform.position.x < -0.2f)
            {
                sagda = false;
                solda = false;
                hareketEdilecek = false;
                transform.position = Vector3.zero;
            }
        }
        
    }
    private void SagaGit()
    {
        transform.position += sag * Time.deltaTime*5;
    }

    void solaGit()
    {
        transform.position += sol * Time.deltaTime*5;
    }

    
}
