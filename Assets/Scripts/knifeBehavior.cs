using UnityEngine;
using System;
using System.Collections.Generic;


public class knifeBehavior : MonoBehaviour
{
    public GameObject cabbagePrefab;
    public GameObject bokChoyPrefab;
    public GameObject brusselSproutPrefab;
    public GameObject tomatoPrefab;

    public int choppedCabbage = 0;
    public int choppedBokChoy = 0;
    public int choppedbrusselSprout = 0;
    public int choppedTomato = 0;
    private int saladMade = 0;

    public List<String> foodOrder = new List<string> {"Cabbage", "Brussel Sprout", "Bok Choy", "Tomato"};    

    void Update() {
        int random = UnityEngine.Random.Range(0,300);
        if(random == 10){
            spawnIngredients();
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mousePosition.z = 0; // Set z to 0 since we're in 2D

        transform.position = mousePosition;

        

    }

    private void addFoodReserves(){
        GameData.globalFoodReserves += 1;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Cabbage")){
            choppedCabbage++;
            Debug.Log("CHOPPED CABBAGE!!");
            addFoodReserves();
        }
        if(collision.gameObject.CompareTag("Brussel Sprout")){
            choppedbrusselSprout++;
            
            Debug.Log("CHOPPED BRUSSEL SPROUT!!");
            addFoodReserves();
        }            
        if(collision.gameObject.CompareTag("Bok Choy")){
            choppedBokChoy++;
            
            Debug.Log("CHOPPED BOK CHOY!!");
            addFoodReserves();
        }
        if(collision.gameObject.CompareTag("Tomato")){
            choppedTomato++;
            
            Debug.Log("CHOPPED TOMATO!!");
            addFoodReserves();
        }
        
        if(choppedCabbage >= 3 && choppedbrusselSprout >= 3 && choppedBokChoy >= 3 && choppedTomato >= 3){
            saladMade += 1;
            choppedCabbage = 0;
            choppedbrusselSprout = 0;
            choppedBokChoy = 0;
            choppedTomato = 0;
        }

        Destroy(collision.gameObject);
    }

    void spawnIngredients(){
        int randNum = UnityEngine.Random.Range(-10, 10);
        int randIndex = UnityEngine.Random.Range(0, 4);
        GameObject foodObject; 

        String spawnedFood = foodOrder[randIndex];
        if (spawnedFood == "Cabbage"){
                foodObject = cabbagePrefab;
        }
        else if (spawnedFood == "Brussel Sprout"){
            foodObject = brusselSproutPrefab;

        }
        else if (spawnedFood == "Bok Choy"){
            foodObject = bokChoyPrefab;
        }
        else {
            foodObject = tomatoPrefab;
        }

        // UnityEngine.Vector3 foodPos = new UnityEngine.Vector3(randNum , 4, 0);
        Instantiate(foodObject, GetRandomPosition(), Quaternion.identity);
    }
    void spawnVeggies(){


    }
    public float spawnOffsetY = 15f;
    public float minX = -8f;
    public float maxX = 8f;

    public Vector2 GetRandomPosition()
    {
        float randomY = UnityEngine.Random.Range(1, 5)+spawnOffsetY;
        float randomX = UnityEngine.Random.Range(minX, maxX);
        return new Vector2(randomX, randomY);
    }

}