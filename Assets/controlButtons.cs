using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class controlButtons : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
        SceneManager.LoadScene("KitchenPrep");
       }
    }
    public void StartGame(){
        SceneManager.LoadScene("OvenMinigame");

    }

     public void ExitScreen(){
        SceneManager.LoadScene("KitchenPrep");

    }
   
}
