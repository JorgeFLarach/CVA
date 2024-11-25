
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
 
 public Vector3 velocity;
 public GameObject topFood;
 public GameObject timer;

 public Vector3 initialDist;

  void Start(){
    plate = GameObject.FindGameObjectWithTag("Plate");
    timer = GameObject.FindGameObjectWithTag("Timer");
    velocity = new Vector3(0, -3f, 0);

  }
 public void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Plate")){
                 if (other.gameObject.transform.position.x - .5f > this.gameObject.transform.position.x) {

                  //Falling to the left
                    this.gameObject.transform.position += new Vector3(-80f, -20f, 0f) * Time.deltaTime;

                  }
                  else if (other.gameObject.transform.position.x + .5f < this.gameObject.transform.position.x) {
                      this.gameObject.transform.position += new Vector3(80f, -20f, 0f) * Time.deltaTime;
                   
                  }

        if (this.gameObject.transform.position.x - .5 <= other.gameObject.transform.position.x && other.gameObject.transform.position.x <= this.gameObject.transform.position.x + .5){
            plate.GetComponent<plateMovement>().stack.Add(this.gameObject);
            plate.GetComponent<plateMovement>().foodOrder.Remove("Pasta");
            plate.GetComponent<plateMovement>().foodOrder.Add("Pasta");
            this.foodCaught = true;
            velocity = new Vector3(0, 0, 0);
          

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

             if (other.gameObject.transform.position.y > this.gameObject.transform.position.y){
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
                        initialDist = plate.transform.position - other.transform.position; //added should it be changed 
                        other.gameObject.GetComponent<CheeseScript>().velocity = new Vector2(0, 0);

                }
                else {
                  //play falling animation
                 if (other.gameObject.transform.position.x < this.gameObject.transform.position.x - 0.5f) {

                  //Falling to the left
                    other.gameObject.transform.position += new Vector3(-80f, -20f, 0f) * Time.deltaTime;

                  }
                  else {
                      other.gameObject.transform.position += new Vector3(80f, -20f, 0f) * Time.deltaTime;
                   
                  }

                }
              }
              
        }
        }
      }
 }
  void Update(){
    if (GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>().gameOver){
      velocity = new Vector3(0, 0, 0);
    }
      if (foodCaught && !GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>().gameOver){
        //move the food in direction of plate
        UnityEngine.Vector3 pos = this.transform.position;
        pos.x = plate.GetComponent<plateMovement>().worldMousePos.x;
        pos.x = Mathf.Clamp(pos.x, -3f, 9f);
        this.transform.position = pos;
        }
      else if(!foodCaught){
        this.transform.position += velocity * Time.deltaTime;
      }
  }

   void OnTriggerEnter2D(Collider2D other){
       if (other.gameObject.CompareTag("lasagnaGround")){
        Destroy(this.gameObject);
       }
    }

   }

