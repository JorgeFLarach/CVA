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
    public int pancakesCost = 2;
    public int iceCreamCost = 20;
    public int salsaCost = 20;
    [SerializeField]
    private GameObject background;

    public Button setPieBtn;
    public Button setSaladBtn;
    public Button setLasagnaBtn;
    public Button setPancakesBtn;
    public Button setIceCreamBtn;
    public Button setSalsaBtn;
    public Button pauseBtn;
    public Button fastForwardBtn;
    public Button forkBtn;

    private bool isForkMode = false;

    public TextMeshProUGUI foodReservesText;
    public TextMeshProUGUI scoreText;
    public Player player;

    public float expectedTime = 1f;
    public float previousTime = 1f;
    public bool paused = false;

    public TextMeshProUGUI pauseButtonText;
    public TextMeshProUGUI fastForwardButtonText;
    public GameObject progressBar;

    void Start()
    {
        GameData.ClearFoodBoard();
        DisplayFoodReserves();
        DisplayScore();
        setCost();
        scaleTime();
        ButtonLogic();
        GenerateTables();
        GameData.UpdateTimes();
    }

    void Update()
    {
        CheckTime();
        CheckFreeze();
        CheckBurn();
        CheckFastForward();
        KeyLogic();
        DisplayFoodReserves();
        DisplayScore();
        ProgressBar();
    }

    void CheckFastForward()
    {
        if (!GameData.isFast && !paused && !GameData.freeze)
        {
            NormalSpeed();
        }
    }

    private void KeyLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFood();
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            forkMode();
        }
    }

    private void ButtonLogic()
    {
        setPieBtn.onClick.AddListener(SetPie);
        setSaladBtn.onClick.AddListener(SetSalad);
        setLasagnaBtn.onClick.AddListener(SetLasagna);
        setPancakesBtn.onClick.AddListener(SetPancakes);
        if (GameData.waveNumber < 3)
        {
            setPancakesBtn.gameObject.SetActive(false);
        }
        setIceCreamBtn.onClick.AddListener(SetIceCream);
        if (GameData.waveNumber < 4)
        {
            setIceCreamBtn.gameObject.SetActive(false);
        }
        setSalsaBtn.onClick.AddListener(SetSalsa);
        if (GameData.waveNumber < 5)
        {
            setSalsaBtn.gameObject.SetActive(false);
        }
        pauseBtn.onClick.AddListener(TogglePause);
        fastForwardBtn.onClick.AddListener(ToggleFastForward);
        // fastForwardBtn.interactable = false;
        forkBtn.onClick.AddListener(forkMode);
        if (pauseButtonText != null)
        {
            pauseButtonText.text = "Pause";
        }
        if (fastForwardButtonText != null)
        {
            fastForwardButtonText.text = ">>";
        }
    }

    IEnumerator ResetTimeScale(float duration)
    {
        GameData.TurnAllBlue();
        yield return new WaitForSeconds(duration);
        GameData.globalTimeScale = GameData.regularTime;
        Time.timeScale = GameData.globalTimeScale;
        GameData.freeze = false;
        GameData.TurnAllWhite();
    }

    private void CheckFreeze()
    {
        if (GameData.freeze)
        {
            StartCoroutine(ResetTimeScale(5));
        }
    }
    IEnumerator DisableBurn()
    {
        yield return new WaitForSeconds(20);
        GameData.burn = false;
        foreach (Tomato tomato in GameData.tomatos)
        {
            tomato.SetSpeed(3);
        }
        foreach (Salad salad in GameData.saladLocations)
        {
            salad.SetTimeScale(3);
        }
        GameData.TurnAllWhite();
    }
    private void CheckBurn()
    {
        if (GameData.burn)
        {
            GameData.BurnEM();
            StartCoroutine(DisableBurn());
        }
    }

    private void SpawnFood()
    {
        // if (paused)
        // {
        //     return;
        // }
        // else
        // {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (worldPosition.y < 4.3 && worldPosition.x > -7)
            {
                if (isForkMode)
                {
                    forkMode();
                    GameData.forkFood(worldPosition);
                }
                else if (paused)
                {
                    return;
                }
                else if (GameData.globalFoodReserves > 0)
                {
                    GameData.globalFoodReserves -= player.PlaceFood(worldPosition);
                }
                else
                {
                    return;
                }
            }

        }
    

    private void setCost()
    {
        player.SetCost(1, pieCost);
        player.SetCost(2, saladCost);
        player.SetCost(3, lasagnaCost);
        player.SetCost(4, pancakesCost);
        player.SetCost(5, iceCreamCost);
        player.SetCost(6, salsaCost);
    }

    private void scaleTime()
    {
        GameData.globalTimeScale = (1 + GameData.makeDecimal(GameData.waveNumber));
        Time.timeScale = GameData.globalTimeScale;
    }

    public void forkMode()
    {
        isForkMode = !isForkMode;
        forkBtn.GetComponent<Image>().color = isForkMode ? Color.red : Color.white;
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
    private void SetPie()
    {
        player.SelectPie();
    }
    private void SetSalad()
    {
        player.SelectSalad();
    }
    private void SetLasagna()
    {
        player.SelectLasagna();
    }
    private void SetPancakes()
    {
        player.SelectPancakes();
    }
    private void SetIceCream()
    {
        player.SelectIceCream();
    }
    private void SetSalsa()
    {
        player.SelectSalsa();
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
    public void ToggleFastForward()
    {
        if (!fastForward)
        {
            FastForward();
            if (fastForwardButtonText != null)
            {
                fastForwardButtonText.text = "<<";
            }
        }
        else
        {
            NormalSpeed();
            if (fastForwardButtonText != null)
            {
                fastForwardButtonText.text = ">>";
            }
        }
    }

    public void PauseGame()
    {
        GreyOutBackground();
        UpdateTimeScale(0);
    }
    public void ResumeGame()
    {
        ResetBackground();
        Time.timeScale = previousTime;
        UpdateTimeScale(previousTime);
    }

    public void CheckTime()
    {
        Time.timeScale = GameData.globalTimeScale;
    }
    private bool fastForward = false;

    public void UpdateTimeScale(float time)
    {
        previousTime = Time.timeScale;
        GameData.globalTimeScale = time;
        Time.timeScale = time;
    }

    public void FastForward()
    {
        if (paused)
        {
            TogglePause();
        }
        else
        {
            fastForward = true;
            GameData.isFast = true;
            ResetBackground();
            paused = false;
            previousTime = Time.timeScale;
            UpdateTimeScale(GameData.globalTimeScale * 3);
        }
    }
    public void NormalSpeed()
    {
        fastForward = false;
        GameData.isFast = false;
        ResetBackground();
        paused = false;
        // Time.timeScale = previousTime;
        GameData.ResumeGame();
        // UpdateTimeScale(previousTime);
    }
    public void GreyOutBackground()
    {
        background.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        foodReservesText.color = new Color(1f, 1f, 1f, 1f);
        scoreText.color = new Color(1f, 1f, 1f, 1f);
    }
    public void ResetBackground()
    {
        background.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        foodReservesText.color = new Color(0f, 0f, 0f, 1f);
        scoreText.color = new Color(0f, 0f, 0f, 1f);
    }

    public void placeTables(int num)
    {
        int rows = 9;
        List<int> availableRows = new List<int>();
        for (int i = 0; i < rows; i++)
        {
            availableRows.Add(i);
        }

        for (int i = 0; i < num; i++)
        {
            if (availableRows.Count == 0)
            {
                for (int j = 0; j < rows; j++)
                {
                    availableRows.Add(j);
                }
            }

            int randomRowIndex = Random.Range(0, availableRows.Count);
            int selectedRow = availableRows[randomRowIndex];
            availableRows.RemoveAt(randomRowIndex);

            float yPos = GameData.LockYPosition(3.7f - (selectedRow * 1.0f));
            float xPos = GameData.LockXPosition(Random.Range(-6.3f, 5.7f));
            Vector2 position = new Vector2(xPos, yPos);
            if (!GameData.isOccupied(position))
            {
                player.PlaceTable(position);
            }
        }
    }

    public void GenerateTables()
    {
        // Debug.Log($"Generating tables for wave {GameData.waveNumber}");
        if (GameData.waveNumber > 2)
        {
            // Debug.Log($"Generating {GameData.waveNumber} tables for wave {GameData.waveNumber}");
            placeTables(GameData.waveNumber);
        }
    }
    private float startWaveTime = GameData.globalWaveTime;

    private float waveDuration = 120f;

    public void ProgressBar()
    {
        if (!paused)
        {
            float progressBarWidth = 14f;
            float moveAmount = progressBarWidth / waveDuration * Time.deltaTime;
            Vector3 currentPos = progressBar.transform.position;
            currentPos.x -= moveAmount * GameData.globalTimeScale;
            currentPos.x = Mathf.Clamp(currentPos.x, -7f, 7f);
            progressBar.transform.position = currentPos;
        }
    }
}
