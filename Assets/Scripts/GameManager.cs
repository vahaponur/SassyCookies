using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
   //Game Situtiation
   private bool gameOver = false;
   private bool success = false;
   private int greenChildCount;

   private bool tekrarlama = false;
   //Game Situtiation
   
   //Objects to give from editor
   [SerializeField] private BolgeAlgilayici bolgeAlgilayici;
    private Transform yesilBolge;
   [SerializeField] private Transform successPanel;
   [SerializeField] private Transform failPanel;
   [SerializeField] private GameObject PlayerNeedle;

   [SerializeField] private TextMeshProUGUI LevelText;
   //Objects to give from editor
   
   private void Start()
   {
      yesilBolge = GameObject.FindWithTag("YesilAna").transform;
      
      greenChildCount = yesilBolge.childCount;
      if (!PlayerPrefs.HasKey("Level"))
      {
         PlayerPrefs.SetInt("Level",1);
      }

      if (!PlayerPrefs.HasKey("OncekiBitis"))
      {
         //1 mean success, 0 mean fail
         PlayerPrefs.SetInt("OncekiBitis",1);
      }
   }
   
   private void Update()
   {
      if ((bolgeAlgilayici.GreenHit == greenChildCount || bolgeAlgilayici.BannedHit > 10) && !tekrarlama)
      {
         gameOver = true;
         if (bolgeAlgilayici.GreenHit == greenChildCount)
         {
            success = true;
         }

         tekrarlama = true;
      }

      if (gameOver)
      {
         Finish(success);
         gameOver = false;
      }
      



   }

   void Finish(bool success)
   {
      if (success)
      {
         PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
         successPanel.gameObject.SetActive(true);
         success = false;
         PlayerPrefs.SetInt("OncekiBitis",1);
      }else
      {
         failPanel.gameObject.SetActive(true);
         PlayerPrefs.SetInt("OncekiBitis",0);

      }
      
      PlayerNeedle.gameObject.SetActive(false);
   }

   public void LoadScene()
   {
      StartCoroutine(ReloadScene());
   }
   IEnumerator ReloadScene()
   {
      AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGameScene");

      // Wait until the asynchronous scene fully loads
      while (!asyncLoad.isDone)
      {
         yield return null;
      }
   }

   private void LateUpdate()
   {
      LevelText.text = "Level " + PlayerPrefs.GetInt("Level").ToString();
   }
}
