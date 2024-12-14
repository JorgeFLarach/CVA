using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; 
    public Button goToMenuBtn;  

    private void Start()
    {
        gameOverText.text = "Game Over\nScore: " + GameData.playerScore;
        
        goToMenuBtn.onClick.AddListener(GoToMenu);
    }

    public void GoToMenu(){
        PlayerPrefs.DeleteAll(); // Not sure what this does
        GameData.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}
