using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int pieCost = 1;
    public int saladCost = 10;
    public int lasagnaCost = 5;
    public int pieHP = 3;
    public int tomatoHP = 1;
    public int saladHP = 20;
    public int lasagnaHP = 10;
    public int pieDmg = 3;
    public int tomatoDmg = 1;
    public int lasagnaDmg = 10;

    public float startSpawnRate = 1f;
    public int startSpawnAmount = 1;
    public float startWaveTime = 50f;


    public Button setPieBtn;
    public Button setSaladBtn;
    public Button setLasagnaBtn;
    public Button pauseBtn;

    public TextMeshProUGUI foodReservesText;
    public TextMeshProUGUI scoreText;
    public Player player;

    public TextMeshProUGUI pauseButtonText;


    public EnemySpawner enemySpawner;

    public float makeDecimal(int wvNum)
    {
        return (float)wvNum / 10f;
    }


    public void startWave()
    {
        enemySpawner.SetWaveTime(startWaveTime * (1 + makeDecimal(GameData.waveNumber)));
        enemySpawner.SetSpawnRate(startSpawnRate * (1 + makeDecimal(GameData.waveNumber)));
        enemySpawner.SetSpawnAmount((int)(startSpawnAmount * (1 + makeDecimal(GameData.waveNumber))));
        enemySpawner.StartSpawning();
    }


    void Update()
    {
        if (Time.timeScale != 0 && Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFood();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        DisplayFoodReserves();
        DisplayScore();
    }

    void SpawnFood()
    {
        if (GameData.globalFoodReserves <= 0)
        {
            return;
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (worldPosition.y < 4.3 && worldPosition.x > -7)
            {
                GameData.globalFoodReserves -= player.PlaceFood(worldPosition);
            }
        }
    }

    void setCost()
    {
        player.SetCost(1, pieCost);
        player.SetCost(2, saladCost);
        player.SetCost(3, lasagnaCost);
    }
    void setHP()
    {
        player.SetHP(1, pieHP);
        player.SetHP(2, tomatoHP);
        player.SetHP(3, saladHP);
        player.SetHP(4, lasagnaHP);
    }
    void setDmg()
    {
        player.SetDmg(1, pieDmg);
        player.SetDmg(2, tomatoDmg);
        player.SetDmg(3, lasagnaDmg);
    }


    void Start()
    {
        DisplayFoodReserves();
        DisplayScore();
        setCost();

        setPieBtn.onClick.AddListener(() => SetPie());
        setSaladBtn.onClick.AddListener(() => SetSalad());
        setLasagnaBtn.onClick.AddListener(() => SetLasagna());
        pauseBtn.onClick.AddListener(() => TogglePause());

        if (pauseButtonText != null)
        {
            pauseButtonText.text = "Pause";
        }
        // startWave();
    }

    public void DisplayScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameData.playerScore;
        }
    }

    public void DisplayFoodReserves()
    {
        if (foodReservesText != null)
        {
            if (GameData.globalFoodReserves >= 0)
            {
                foodReservesText.text = "Food Reserves: " + GameData.globalFoodReserves;
            }
            else
            {
                foodReservesText.text = "Food Reserves: 0";
            }
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
    public void SetLasagna()
    {
        player.SelectLasagna();
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
            if (pauseButtonText != null)
            {
                pauseButtonText.text = "Pause";
            }
        }
        else
        {
            PauseGame();
            if (pauseButtonText != null)
            {
                pauseButtonText.text = "Resume";
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
