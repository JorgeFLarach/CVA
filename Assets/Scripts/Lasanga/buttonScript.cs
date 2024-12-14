using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{

    void Update(){
       if(Input.GetKeyDown(KeyCode.Escape)){
        SceneManager.LoadScene("KitchenPrep");
       }
    }
    public void StartGame(){
          SceneManager.LoadScene("LasagnaMiniGame");
    }

    public void ExitGame(){
           SceneManager.LoadScene("KitchenPrep");
    }
    
}