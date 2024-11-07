using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int highScore;
    public int foodReserves = 200;
    // public UnityEngine.UI.Text foodReservesText;
    public TextMeshProUGUI foodReservesText;


    // public EnemySpawner enemySpawner;

    public void AddScore(int score)
    {
        this.score += score;
    }
    public GameObject foodPrefab;

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
            Instantiate(foodPrefab, worldPosition, Quaternion.identity);
            foodReserves--;
        }
    }

    private void GameOver()
    {
        if(foodReserves <= 0)
        {
            Debug.Log("Game Over! You ran out of food Monsters!");
            SceneManager.LoadScene("GameOver");
        }
    }


    void Start()
    {
        UpdateFoodReservesText();
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
}
