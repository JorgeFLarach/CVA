using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class VeggieTimer : MonoBehaviour
{
    public float countdown = 20f;
    
    public TMP_Text timerText;
    
    void Update()
    {
         if (countdown > 0){
            countdown -= Time.deltaTime;
            timerText.text = countdown.ToString().Split('.')[0];
        }

        if (countdown < 0){
           SceneManager.LoadScene("KitchenPrep");
    }
}
}