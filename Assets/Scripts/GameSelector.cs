using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameSelector : MonoBehaviour
{

    // public int WC = 1;
    // public TextMeshProUGUI waveCountText;

    // public void DisplayWaveCount()
    // {
    //     // int wc = FindFirstObjectByType<EnemySpawner>().WaveCount++;
    //     waveCountText.text = "Wave " + WC;
    // }
    // public void Start()
    // {
    //     DisplayWaveCount();
    //     WC++;
    // }
    // public void Update()
    // {
    //     DisplayWaveCount();
    // }
    public void BattleGround()
    {
        SceneManager.LoadScene("Kitchen");
    }
    public void Menu()
    {
        SceneManager.LoadScene("GameSelector");
    }
    public void Lasanga()
    {
        SceneManager.LoadScene("LasagnaStartGame");
    }
    public void Pizza()
    {
        SceneManager.LoadScene("Pizza");
    }
    public void ChopVeggies()
    {
        SceneManager.LoadScene("ChopVeggies");
    }


}
