using System;
using System.Collections.Generic;
using UnityEngine;


public class knifeBehavior : MonoBehaviour
{
    public GameObject cabbagePrefab;
    public GameObject bokChoyPrefab;
    public GameObject brusselSproutPrefab;

    public int choppedCabbage = 0;
    public int choppedBokChoy = 0;
    public int choppedbrusselSprout = 0;

    private int saladMade = 0;

    public List<String> foodOrder = new List<string> {"Cabbage", "Brussel Sprout", "Bok Choy"};    

    void Update() {
        int random = UnityEngine.Random.Range(0,600);
        if(random == 10){
            spawnIngredients();
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 since we're in 2D

        transform.position = mousePosition;

        

    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Cabbage")){
            choppedCabbage++;
            Debug.Log("CHOPPED CABBAGE!!");
        }
        if(collision.gameObject.CompareTag("Brussel Sprout")){
            choppedbrusselSprout++;
            
            Debug.Log("CHOPPED BRUSSEL SPROUT!!");
        }            
        if(collision.gameObject.CompareTag("Bok Choy")){
            choppedBokChoy++;
            
            Debug.Log("CHOPPED BOK CHOY!!");
        }
        
        if(choppedCabbage >= 3 && choppedbrusselSprout >= 3 && choppedBokChoy >= 3){
            saladMade += 1;
            choppedCabbage = 0;
            choppedbrusselSprout = 0;
            choppedBokChoy = 0;
        }

        Destroy(collision.gameObject);
    }

    void spawnIngredients(){
        int randNum = UnityEngine.Random.Range(-10, 10);
        int randIndex = UnityEngine.Random.Range(0, 3);
        GameObject foodObject; 

        String spawnedFood = foodOrder[randIndex];
        if (spawnedFood == "Cabbage"){
                foodObject = cabbagePrefab;
        }
        else if (spawnedFood == "Brussel Sprout"){
            foodObject = brusselSproutPrefab;

        }
        else {
            foodObject = bokChoyPrefab;
        }

        UnityEngine.Vector3 foodPos = new UnityEngine.Vector3(randNum , 4, 0);
        Instantiate(foodObject, foodPos, UnityEngine.Quaternion.identity);
    }

}