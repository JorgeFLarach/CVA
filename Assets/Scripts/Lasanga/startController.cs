using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startController : MonoBehaviour
{
    public GameObject rulesPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void StartGame(){
        SceneManager.LoadScene("KitchenPrep");
    }
    public void OpenRules(){
        rulesPanel.SetActive(true);
    }
    public void ExitRules(){
        rulesPanel.SetActive(false);
    }
    public void StartTutorial(){
        SceneManager.LoadScene("Tutorial");
    }
    

}
