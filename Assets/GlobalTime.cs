using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class GlobalTime : MonoBehaviour
{    
    public TMP_Text clock;
    public float timer;
 
    public void Start(){

      if (!PlayerPrefs.HasKey("Timer")){
       Debug.Log("setting timer");
       PlayerPrefs.SetFloat("Timer", 70);
       PlayerPrefs.Save();
      }
    }
   public void Update(){
        timer = PlayerPrefs.GetFloat("Timer");
        clock.text = timer.ToString().Split('.')[0];
          if (timer > 0){
            timer -= Time.deltaTime;
            PlayerPrefs.SetFloat("Timer", timer);
            PlayerPrefs.Save();
        }

        else if (timer < 0){
            Debug.Log("timer complete");
         // show panel quickly then go to battle ground
        }
    }

}