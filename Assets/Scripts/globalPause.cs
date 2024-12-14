using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class GlobalPause : MonoBehaviour
{    
    public TMP_Text clock;
    public float timer;
 
    public void Start(){
        timer = PlayerPrefs.GetFloat("Timer");
        clock.text = timer.ToString().Split('.')[0];
    }
}