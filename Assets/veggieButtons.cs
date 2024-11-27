using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class veggieButtons : MonoBehaviour
{
   public void StartGame(){
    SceneManager.LoadScene("SaladGame");
   }
   
    public void ExitGame(){
    SceneManager.LoadScene("KitchenPrep");
   }
}
