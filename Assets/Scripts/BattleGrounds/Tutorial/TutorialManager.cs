using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public GameManager gameManager;
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI tutorialText;

    void Start()
    {
        tutorialText.text = "Welcome to the tutorial! (Press the enter to continue!)";
        StartCoroutine(TutorialText());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterPressed();
        }
    }

    private void EnterPressed()
    {
        Time.timeScale = 1;
    }

    private void RedirectToGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator TutorialText()
    {
        gameManager.pauseButtonText.text = "Resume";
        enemySpawner.enabled = false;
        gameManager.GreyOutBackground();
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You will need to place food to prevent the aliens from getting behind the counter!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can place food by clicking on the food you want to place and then clicking or pressing space on the location you want to place it.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can select the type of food you want to place by clicking on the food you want in the top left or pressing the corresponding number on your keyboard.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can throw pies by clicking on the pie and then clicking on the location you want to throw it.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "Be careful not to waste your food reserves because you have a limited amount!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can also place salads to throw tomatoes at the aliens for you!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can place Lasagnas to block the aliens from getting behind the counter! Be careful because the aliens can eat your food!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "Placing pancakes will get aliens stuck in sticky syrup! Watch out because other aliens will still be able to push the frozen aliens into you!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "The goal is to make it through as many waves as possible! You will be able to restock on food reserves in between waves, but cook fast because you will not have much time before more aliens arrive!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can pause the game by pressing the pause button in the top right or pressing the p key.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can resume the game by pressing the resume button in the top right or pressing the p key again.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "You can also press f to toggle fast forward once you feel you have a strong set up, however we would not recomend that until you have become more familar with how to play the game.";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "Good luck!\n (Press enter when you are ready!)";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        enemySpawner.enabled = true;
        gameManager.ResetBackground();
        tutorialText.text = "";
        yield return new WaitForSeconds(60f);

        tutorialText.text = "You have completed the tutorial! Press enter to return to the main menu!";
        gameManager.PauseGame();
        yield return new WaitForSeconds(0.5f);
        RedirectToGame();
    }

}
