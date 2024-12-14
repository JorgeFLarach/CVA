using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPlayerPref : MonoBehaviour
{
    public void Awake(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
