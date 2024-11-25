using System.Collections;
using System.Collections.Generic;
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
    public int pieDmg = 3;
    public int tomatoDmg = 1;
    public int lasangaDmg = 10;


    public Button setPieBtn;
    public Button setSaladBtn;
    public Button setLasangaBtn;
    public Button pauseBtn;

    public TextMeshProUGUI foodReservesText;
    public Player player;

    public TextMeshProUGUI pauseButtonText;

    public void AddScore(int score)
    {
        this.score += score;
    }


    void Update()
    {
        if (Time.timeScale != 0 && Input.GetMouseButtonDown(0))
        {
            SpawnFood();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        DisplayFoodReserves();
    }

    void SpawnFood()
    {
        if(foodReserves <= 0)
        {
            return;
        }else {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if(worldPosition.y < 4.3 && worldPosition.x > -7){
                foodReserves -= player.PlaceFood(worldPosition);
            }
        }
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
    void setDmg(){
        player.SetDmg(1, pieDmg);
        player.SetDmg(2, tomatoDmg);
        player.SetDmg(3, lasangaDmg);
    }


    void Start()
    {
        UpdateFoodReservesText();
        setCost();

        setPieBtn.onClick.AddListener(() => SetPie());
        setSaladBtn.onClick.AddListener(() => SetSalad());
        setLasangaBtn.onClick.AddListener(() => SetLasanga());
        pauseBtn.onClick.AddListener(() => TogglePause());

        if (pauseButtonText != null)
        {
            pauseButtonText.text = "Pause";
        }
    }

    public void DisplayFoodReserves()
    {
        UpdateFoodReservesText();
    }

    void UpdateFoodReservesText()
    {
        if (foodReservesText != null)
        {
            if(foodReserves >= 0){
                foodReservesText.text = "Food Reserves: " + foodReserves;
            }
            else{
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
    public void SetLasanga()
    {
        player.SelectLasanga();
    }

    public void TogglePause(){
        if(Time.timeScale == 0){
            ResumeGame();
            if (pauseButtonText != null)
            {
                pauseButtonText.text = "Pause";
            }
        }else{
            PauseGame();
            if (pauseButtonText != null)
            {
                pauseButtonText.text = "Resume";
            }
        }
    }
    public void PauseGame(){
        Time.timeScale = 0;
    }
    public void ResumeGame(){
        Time.timeScale = 1;
    }
}
