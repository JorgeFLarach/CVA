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
           
            // can adjust with time and play
            if (plate.GetComponent<plateMovement>().stack.Count <= 4){
                earnedMonsters = 2;
            }
            else if (plate.GetComponent<plateMovement>().stack.Count <= 8){
                earnedMonsters = 5;
            }
            else if(plate.GetComponent<plateMovement>().stack.Count <= 11){
                earnedMonsters = 8;
            }
            else {
                earnedMonsters = 10;
            }
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
         SceneManager.LoadScene("LasagnaStartGame");
         
        }
        
    }

