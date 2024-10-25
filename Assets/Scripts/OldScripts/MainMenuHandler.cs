using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PointerEnterButton(String buttonName) {
        GameObject.Find(buttonName).transform.localScale = new Vector2(2,2);
    }

    public void PointerExitButton(String buttonName) {
        GameObject.Find(buttonName).transform.localScale = new Vector2(1,1);
    }
    public void LoadPlatformer() {
        Debug.Log("Loading platformer");
        SceneManager.LoadScene(1);
    }

    public void LoadBreakout() {
        Debug.Log("Loading breakout");
        SceneManager.LoadScene(2);
    }

    public void LoadAnimation() {
        Debug.Log("Loading animation");
        SceneManager.LoadScene(3);
    }

    public void QuitGame() {
        if (Application.isEditor) {
            EditorApplication.ExitPlaymode();
        }
        Application.Quit();
    }
}
