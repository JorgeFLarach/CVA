using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SkipButton : MonoBehaviour
{

    public Button skipButton;

    void Start()
    {
        skipButton.onClick.AddListener(Skip);
    }

    void Skip()
    {
        SceneManager.LoadScene("KitchenPrep");
    }
}
