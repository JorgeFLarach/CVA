using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class fillClock : MonoBehaviour
{
   public UnityEngine.UI.Image fill;
   public float currTime;
   public float totTime;
    // Update is called once per frame
    public void Start(){
    
     totTime = 70f;
    }
    public void Update(){
        currTime = PlayerPrefs.GetFloat("Timer");
        Debug.Log(currTime);
        fill.fillAmount = Mathf.InverseLerp(0, totTime, currTime);
        
    }
}
