using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour {
    public GameObject winPanel;
    public TMP_Text text;
     public TMP_Text winPanelText;
    float countdown = 20;
    public GameObject losePanel; 
    public GameObject plate; 
    public int earnedMonsters = 0;
    public bool gameOver = false;

    void Update(){
      if(!gameOver){
        if (countdown > 0){
            countdown -= Time.deltaTime;
        }

        if (countdown < 0){
            winPanel.SetActive(true);
            gameOver = true;
           
            if (plate.GetComponent<plateMovement>().stack.Count <= 3){
                earnedMonsters = 15;
            }
            else if (plate.GetComponent<plateMovement>().stack.Count <= 6){
                earnedMonsters = 30;
            }
            else if(plate.GetComponent<plateMovement>().stack.Count <= 8){
                earnedMonsters = 45;
            }
            else {
                earnedMonsters = 55;
            }
          PlayerPrefs.SetInt("LasagnaEarned", earnedMonsters);
          winPanelText.text = $"You earned {earnedMonsters} lasagna monsters! ";
          Invoke("MainMenu", 4f);
        }

    text.text = countdown.ToString();
      }
    }

    public void EndGame(){
         gameOver = true;
         losePanel.SetActive(true);
         Invoke("MainMenu", 3f);
        }

     public void MainMenu(){
         SceneManager.LoadScene("KitchenPrep");
         
        }
        
    }

