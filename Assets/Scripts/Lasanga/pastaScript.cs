
using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;



public class PastaScript : MonoBehaviour
{
public TMP_Text lossText;
 public bool foodCaught = false; 
 public float speed = 2f;
 public String correctItem; 
 public GameObject plate;

 public GameObject topFood;
 public GameObject timer;

  void Start(){
    plate = GameObject.FindGameObjectWithTag("Plate");
    timer = GameObject.FindGameObjectWithTag("Timer");

  }
 private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Plate")){
        if(this.gameObject.transform.position.x - .5 <= other.gameObject.transform.position.x && other.gameObject.transform.position.x <= this.gameObject.transform.position.x + .5){
            plate.GetComponent<plateMovement>().stack.Add(this.gameObject);
            plate.GetComponent<plateMovement>().foodOrder.Remove("Pasta");
            plate.GetComponent<plateMovement>().foodOrder.Add("Pasta");
            this.foodCaught = true;

        }
      } 

      
      else {
        if (!this.foodCaught) {
              if (other.gameObject.CompareTag("Pasta") || other.gameObject.CompareTag("Cheese") || other.gameObject.CompareTag("Sauce")) {
                // Ignore collisions with food in air
                return; 
            }
        }

        else if(this.foodCaught){//if pasta caught 
            correctItem = "Cheese";

             if (other.gameObject.transform.position.y >this.gameObject.transform.position.y){
                  topFood = other.gameObject;
              }
              else {
                topFood = this.gameObject;
              }
                if(!other.gameObject.CompareTag(correctItem) && topFood != this.gameObject){
                  timer.GetComponent<timer>().EndGame(); 
              }
              else {
                if (topFood != this.gameObject && other.gameObject.tag == "Cheese" && !other.gameObject.GetComponent<CheeseScript>().foodCaught){
                    if(this.gameObject.transform.position.x - .5 <= other.gameObject.transform.position.x && other.gameObject.transform.position.x <= this.gameObject.transform.position.x + .5){
                        plate.GetComponent<plateMovement>().stack.Add(other.gameObject);
                        plate.GetComponent<plateMovement>().foodOrder.Remove(correctItem);
                        plate.GetComponent<plateMovement>().foodOrder.Add(correctItem);
                        other.gameObject.GetComponent<CheeseScript>().foodCaught = true;

                }
              }
              
        }
        }
      }
 }
  void Update(){
    if (GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>().gameOver){
      //remove rigid body?  //NEED TO FIX
      Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
     // rb.isKinematic = true; // pause movement // pauseGame
      Destroy(rb);
    }
      if (plate.GetComponent<plateMovement>().isMoving && foodCaught && !GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>().gameOver){
        //move the food in direction of plate
        UnityEngine.Vector3 pos = this.transform.position;
        pos.x += plate.GetComponent<plateMovement>().mouseMove * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -3f, 9f);
        this.transform.position = pos;
        }
  }

   void OnTriggerEnter2D(Collider2D other){
       if (other.gameObject.CompareTag("lasagnaGround")){
        Destroy(this.gameObject);
       }
    }

   }

