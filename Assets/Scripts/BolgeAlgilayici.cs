using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolgeAlgilayici : MonoBehaviour
{
    [SerializeField] private CamShake CamShake;
    private int bannedHit = 0;
    private int greenHit = 0;
    [SerializeField]private ParticleSystem _particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("KirmiziBolge"))
        {
            bannedHit++;
            CamShake.hareketEdilecek = true;
        }

        if (other.gameObject.CompareTag("YesilBolge"))
        {
            greenHit++;
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _particleSystem.Play();
        if (!other.gameObject.CompareTag("Tabak"))
        {
            
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _particleSystem.Stop();
    }

    public int BannedHit => bannedHit;
    public int GreenHit => greenHit;
}
