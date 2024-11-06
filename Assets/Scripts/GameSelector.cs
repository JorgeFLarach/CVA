using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelector : MonoBehaviour
{
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
        SceneManager.LoadScene("Breakout");
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
