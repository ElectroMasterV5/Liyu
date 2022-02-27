using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
   public Image[] images;
   private bool Fish1Won;
   private bool Fish2Won;

   private void OnTriggerEnter2D(Collider2D other)
   {
      switch (other.name)
      {
         case "Fish":
            Fish1Won = true;
            if (Fish1Won && !Fish2Won)//someone has won the game
            {
               images[0].gameObject.SetActive(true);//win
               other.GetComponent<FishControl>().DisableControl();
            }
            if (Fish2Won)
            {
               images[1].gameObject.SetActive(true);//lose
               other.GetComponent<FishControl>().DisableControl();
            }
            break;
         case "Fish2":
            Fish2Won = true;
            if (Fish2Won && !Fish1Won)//someone has won the game
            {
               images[2].gameObject.SetActive(true);//win
               other.GetComponent<FishControl2>().DisableControl();
            }
            else if (Fish1Won)
            {
               images[3].gameObject.SetActive(true);//lose
               other.GetComponent<FishControl2>().DisableControl();
            }
            break;
      }
   }
}
