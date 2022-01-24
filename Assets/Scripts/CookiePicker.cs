using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CookiePicker : MonoBehaviour
{
    public GameObject[] cookies;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("OncekiCookie"))
        {
            int rancom = Random.Range(0, cookies.Length);
            GameObject secim = cookies[rancom];
            secim.SetActive(true);
         PlayerPrefs.SetString("OncekiCookie",secim.name);   
        }
        else
        {
            if (PlayerPrefs.GetInt("OncekiBitis") == 0)
            {
                GameObject bisi = null;
                foreach (var VARIABLE in cookies)
                {
                    if (VARIABLE.name == PlayerPrefs.GetString("OncekiCookie"))
                    {
                        VARIABLE.SetActive(true);
                        break;
                    }
                }
                
            }
            else
            {
                int rancom = Random.Range(0, cookies.Length);
                GameObject secim = cookies[rancom];
                secim.SetActive(true);
                PlayerPrefs.SetString("OncekiCookie",secim.name);  
            }
        }
       
      
    }
}
