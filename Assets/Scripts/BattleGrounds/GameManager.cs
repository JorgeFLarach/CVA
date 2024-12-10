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
    public int pancakesCost = 10;

    public float startSpawnRate = 1f;
    public int startSpawnAmount = 1;
    public float startWaveTime = 50f;

    [SerializeField]
    private GameObject background;

    public Button setPieBtn;
    public Button setSaladBtn;
    public Button setLasagnaBtn;
    public Button setPancakesBtn;
    public Button pauseBtn;
    public Button fastForwardBtn;

    public TextMeshProUGUI foodReservesText;
    public TextMeshProUGUI scoreText;
    public Player player;

    public float time = 1f;
    public bool paused = false;

    public TextMeshProUGUI pauseButtonText;
    public TextMeshProUGUI fastForwardButtonText;

    public float makeDecimal(int wvNum)
    {
        return (float)wvNum / 10f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFood();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
	if (Input.GetKeyDown(KeyCode.F))
	{
		ToggleFastForward();
	}

        DisplayFoodReserves();
        DisplayScore();
    }

    void SpawnFood()
    {
        if (GameData.globalFoodReserves <= 0 || paused){
            return;
        }else{
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
        player.SetCost(4, pancakesCost);
    }
    void setHP()
    {
        player.SetHP(1, pieHP);
        player.SetHP(2, tomatoHP);
        player.SetHP(3, saladHP);
    }
    void setDmg()
    {
        player.SetDmg(1, pieDmg);
        player.SetDmg(2, tomatoDmg);
        player.SetDmg(3, lasagnaDmg);
    }

    void scaleTime(){
        time = (1+ makeDecimal(GameData.waveNumber));
        Time.timeScale = time;
    }


    void Start()
    {
        DisplayFoodReserves();
        DisplayScore();
        setCost();
        scaleTime();

        setPieBtn.onClick.AddListener(() => SetPie());
        setSaladBtn.onClick.AddListener(() => SetSalad());
        setLasagnaBtn.onClick.AddListener(() => SetLasagna());
        setPancakesBtn.onClick.AddListener(() => SetPancakes());
        pauseBtn.onClick.AddListener(() => TogglePause());
        fastForwardBtn.onClick.AddListener(() => ToggleFastForward());
        if (pauseButtonText != null)
        {
            pauseButtonText.text = "Pause";
        }
        if (fastForwardButtonText != null){
            fastForwardButtonText.text = ">>";
        }
        GenerateTables();
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
    public void SetPancakes()
    {
        player.SelectPancakes();
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
            paused = false;
            if (pauseButtonText != null)
            {   
                pauseButtonText.text = "Pause";
            }
        }
        else
        {
            PauseGame();
            paused = true;
            if (pauseButtonText != null)
            {
                pauseButtonText.text = "Resume";
            }
        }
    }
    public void ToggleFastForward(){
        if (!fastForward){
            FastForward();
            if (fastForwardButtonText != null){
                fastForwardButtonText.text = "<<";
            }
        }else{
            NormalSpeed();
            if (fastForwardButtonText != null){
                fastForwardButtonText.text = ">>";
            }
        }
    }
    public void GreyOutBackground(){
        background.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        foodReservesText.color = new Color(1f, 1f, 1f, 1f);
        scoreText.color = new Color(1f, 1f, 1f, 1f);
    }
    public void ResetBackground(){
        background.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        foodReservesText.color = new Color(0f, 0f, 0f, 1f);
        scoreText.color = new Color(0f, 0f, 0f, 1f);
    }

    public void PauseGame()
    {
        GreyOutBackground();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        ResetBackground();
        Time.timeScale = time;
    }
    private bool fastForward = false;

    public void FastForward(){
        // time = 3*time;
        fastForward = true;
	ResetBackground();
	paused = false;
        Time.timeScale = time*3;
    }
    public void NormalSpeed(){
        // time = time/3;
        fastForward = false;
	ResetBackground();
	paused = false;
        Time.timeScale = time;
    }

    public void placeTables(int num){
        int rows = 9;
        List<int> availableRows = new List<int>();
        for (int i = 0; i < rows; i++) {
            availableRows.Add(i);
        }

        for (int i = 0; i < num; i++) {
            if (availableRows.Count == 0) {
                for (int j = 0; j < rows; j++) {
                    availableRows.Add(j);
                }
            }

            int randomRowIndex = Random.Range(0, availableRows.Count);
            int selectedRow = availableRows[randomRowIndex];
            availableRows.RemoveAt(randomRowIndex);

            float yPos = GameData.LockYPosition(3.7f - (selectedRow * 1.0f));
            float xPos = GameData.LockXPosition(Random.Range(-6.3f, 5.7f));
            Vector2 position = new Vector2(xPos, yPos);
            if (!GameData.isOccupied(position)) {
                player.PlaceTable(position);
            }
        }
    }

    public void GenerateTables(){
        Debug.Log($"Generating tables for wave {GameData.waveNumber}");
        if (GameData.waveNumber > 2){
            Debug.Log($"Generating {GameData.waveNumber} tables for wave {GameData.waveNumber}");
            placeTables(GameData.waveNumber);
        }
    }
}
