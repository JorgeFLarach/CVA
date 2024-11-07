using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class plateMovement : MonoBehaviour
{
    public float speed = 1f;
    public bool isMoving = false;
    public int stackCount = 0;
    public float startMousePos;
    public float mouseMove;
    public float timelapsed = .05f;
    public float time = 0f;
    public List<String> foodOrder = new List<string> {"Pasta", "Cheese", "Sauce"};
    public List<GameObject> stack; 

    void Start(){

    }
    void Update(){
        if(!(GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>().gameOver)){
            time += Time.deltaTime;
            if (time >= timelapsed){
                // reset time 
                time = 0.0f;
                spawnFoods();
            }
        
        if (Input.GetMouseButtonDown(0)){
            isMoving = true;
            startMousePos = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0)){
            isMoving = false;
        }

        if (isMoving){
            float currPos = Input.mousePosition.x;
            mouseMove = currPos - startMousePos;
            UnityEngine.Vector3 plateTransform = transform.position;
            // adding movement to the vector
            plateTransform.x += mouseMove * speed * Time.deltaTime;
             // ensure plate doesnt move beyond screen
             plateTransform.x = Mathf.Clamp(plateTransform.x, -3f, 9f);
            //setting transform for that vector
            transform.position = plateTransform;
            startMousePos = currPos;
        }
        
    }
    }

    void spawnFoods(){
          float randNum = UnityEngine.Random.Range(-3f, 3f);
          float randNum2 = UnityEngine.Random.Range(3f, 9f);
          int randIndex = UnityEngine.Random.Range(0, 2); 
          GameObject foodObject; 

          String spawnedFood = foodOrder[randIndex];
          UnityEngine.Vector3 foodPos = new UnityEngine.Vector3(randNum , 5, 0);
        
          foodObject = (GameObject)Resources.Load($"Prefabs/{spawnedFood}", typeof(GameObject));  
          Instantiate(foodObject, foodPos, UnityEngine.Quaternion.identity);

          //spawn second needed item 
         UnityEngine.Vector3 foodPos2 = new UnityEngine.Vector3(randNum2, 5, 0);
         foodObject = (GameObject)Resources.Load($"Prefabs/{foodOrder[0]}", typeof(GameObject));  
         Instantiate(foodObject, foodPos2, UnityEngine.Quaternion.identity);

    }

    }
    

