using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class plateMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cheesePrefab;
    public GameObject pastaPrefab;
    public GameObject saucePrefab;
    public float speed = 2f;
    public bool isMoving = false;
    public int stackCount = 0;

    public float startMousePos;

    public List<String> foodOrder = new List<string> {"Pasta", "Cheese", "Sauce"};

  

    
    void Update(){
       int random = UnityEngine.Random.Range(0,150);
        if(random == 10){
            spawnFoods();
        }

        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Down mouse played ");
            isMoving = true;
            startMousePos = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0)){
            isMoving = false;
        }

        if (isMoving){
            float currPos = Input.mousePosition.x;
            float mouseMov = currPos - startMousePos;
            UnityEngine.Vector3 plateTransform = transform.position;
            plateTransform.x += mouseMov * speed * Time.deltaTime;
            transform.position = plateTransform;

            startMousePos = currPos;

        }

    }

    void OnCollisionEnter2D(Collision2D other){
        String correctItem = foodOrder[0];
        Debug.Log("correct item" + correctItem);
            if (other.gameObject.CompareTag(correctItem)){
                // catch item on plate
                foodOrder.Remove(correctItem);
                foodOrder.Add(correctItem);
                Debug.Log("curr list: " + foodOrder[0]);
                stackCount +=1;

            }
            else {
                Debug.Log("loading lose scene");
                //SceneManager.LoadScene("gameOver");
            }
        }

    void spawnFoods(){
          int randNum = UnityEngine.Random.Range(-10, 10);
          int randIndex = UnityEngine.Random.Range(0, 3);
          GameObject foodObject; 

          String spawnedFood = foodOrder[randIndex];
          if (spawnedFood == "Cheese"){
                 foodObject = cheesePrefab;
          }
          else if (spawnedFood == "Pasta"){
            foodObject = pastaPrefab;

          }
          else {
            foodObject = saucePrefab;
          }
   
          UnityEngine.Vector3 foodPos = new UnityEngine.Vector3(randNum , 4, 0);
          Instantiate(foodObject, foodPos, UnityEngine.Quaternion.identity);
    }

    }
    

