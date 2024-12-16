using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class WaveScreen : MonoBehaviour
{
    public TextMeshProUGUI waveText; 
    public Button goToMenuBtn;  

    private void Start()
    {
        waveText.text = "Wave " + GameData.waveNumber;
        goToMenuBtn.onClick.AddListener(GoToMenu);
        GameData.isFast = false;
        GameData.paused = false;
        GameData.freeze = false;
        GameData.ResumeGame();
        GameData.burn = false;
        GameData.ClearFoodBoard();
    }

    public void GoToMenu(){
        PlayerPrefs.DeleteAll(); // Not sure what this does
        SceneManager.LoadScene("SourceInput1");
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.L)){
            GameData.SkipKitchenPrep();
        }
    }
}
