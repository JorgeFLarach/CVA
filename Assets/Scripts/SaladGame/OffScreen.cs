using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OffScreen : MonoBehaviour
{

    public int lives = 5;
    public GameObject knife;
    public void GameOver(){
        PlayerPrefs.SetInt("inMinigame", 0);
        int saladMade = knife.GetComponent<knifeBehavior>().foodCollected;
        PlayerPrefs.SetInt("Veggie", saladMade);
        SceneManager.LoadScene("KitchenPrep");
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Cabbage" || collision.gameObject.tag == "Brussel Sprout"|| collision.gameObject.tag == "Bok Choy"|| collision.gameObject.tag == "Tomato"){
            lives--;
            Destroy(collision.gameObject);
            if(lives == 0){
                GameOver();
            }
        }

    }

}
