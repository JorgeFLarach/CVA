using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoretext;
    public GameObject Panel;
    public Vector3 loc;
    public Vector3 elsewhere;
    public int score = 0;

    void Start()
    {
        //elsewhere = new Vector3 (100f,100f,1f);
        //Panel.SetActive(false);
        //loc = Panel.transform.position;
        //Panel.transform.position = elsewhere;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amt) {
        score = score+amt;
        scoretext.SetText(""+score);
    }

    

    public void Menu()
    {
        SceneManager.LoadScene("GameSelector");
    }

    public void Complete(){
        //Panel.SetActive(true);
        //Panel.transform.position = loc;
        
        Debug.Log("Game Over");
    }

}
