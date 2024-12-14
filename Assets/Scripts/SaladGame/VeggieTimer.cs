using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class VeggieTimer : MonoBehaviour
{
    public float countdown = 60f;

    public GameObject knife;
    
    public TMP_Text timerText;

    void Start(){
     PlayerPrefs.SetInt("inMinigame", 1);
    }
    
    void Update()
    {
         if (countdown > 0){
            countdown -= Time.deltaTime;
            timerText.text = countdown.ToString().Split('.')[0];
        }

        if (countdown < 0){
           PlayerPrefs.SetInt("inMinigame", 0);
           int saladMade = knife.GetComponent<knifeBehavior>().saladMade;
           PlayerPrefs.SetInt("Veggie", saladMade);
           SceneManager.LoadScene("KitchenPrep");
    }
}
}