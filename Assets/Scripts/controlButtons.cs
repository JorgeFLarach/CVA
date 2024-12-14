using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class controlButtons : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("OvenMinigame");

    }

     public void ExitScreen(){
        SceneManager.LoadScene("KitchenPrep");

    }
   
}
