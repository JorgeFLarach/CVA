using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int highScore;
    public int foodReserves = 200;
    public int pieCost = 1;
    public int saladCost = 10;
    public int lasangaCost = 5;
    public int pieHP = 3;
    public int tomatoHP = 1;
    public int saladHP = 20;
    public int lasangaHP = 10;

    // public UnityEngine.UI.Text foodReservesText;
    public TextMeshProUGUI foodReservesText;
    public Player player;

    // public EnemySpawner enemySpawner;

    public void AddScore(int score)
    {
        this.score += score;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFood();

        }
        GameOver();
        DisplayFoodReserves();
    }

    void SpawnFood()
    {
        if(foodReserves <= 0)
        {
            return;
        }else {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // Set this to be the distance from the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // Instantiate(foodPrefab, worldPosition, Quaternion.identity);
            // foodReserves--;
            if(worldPosition.y < 4.3 && worldPosition.x > -7){
                // Debug.Log(worldPosition.y);
                foodReserves -= player.PlaceFood(worldPosition);
            }
        }
    }

    private void GameOver()
    {
        // if(foodReserves <= 0)
        // {
        //     Debug.Log("Game Over! You ran out of food Monsters!");
        //     SceneManager.LoadScene("GameOver");
        // }
    }
    void setCost(){
        player.SetCost(1, pieCost);
        player.SetCost(2, saladCost);
        player.SetCost(3, lasangaCost);
    }
    void setHP(){
        player.SetHP(1, pieHP);
        player.SetHP(2, tomatoHP);
        player.SetHP(3, saladHP);
        player.SetHP(4, lasangaHP);
    }


    void Start()
    {
        UpdateFoodReservesText();
        setCost();

    }

    public void DisplayFoodReserves()
    {
        Debug.Log("Food Reserves: " + foodReserves);
        UpdateFoodReservesText();
    }

    void UpdateFoodReservesText()
    {
        if (foodReservesText != null)
        {
            foodReservesText.text = "Food Reserves: " + foodReserves;
        }
    }
    public void SetPie()
    {
        player.SelectPie();
    }
    public void SetSalad()
    {
        player.SelectSalad();
    }
}
