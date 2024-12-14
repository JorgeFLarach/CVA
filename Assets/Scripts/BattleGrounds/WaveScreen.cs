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
        GameData.ClearFoodBoard();
    }

    public void GoToMenu(){
        PlayerPrefs.DeleteAll(); // Not sure what this does
        SceneManager.LoadScene("KitchenPrep");
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.L)){
            GameData.SkipKitchenPrep();
        }
    }
}
