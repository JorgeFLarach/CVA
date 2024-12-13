using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Brute : MonoBehaviour
{
    public float speed = 0.5f;
    public float lifeTime = 30f;
    public float lives = 15;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pancakes")){

            GameData.playerScore += 500;
            speed = 0;
            spriteRenderer.color = new Color(0.4f, 0.075f, 0.075f, 1f); // Dark red color

        }
        if (collision.gameObject.CompareTag("Food"))
        {
            lives--;
            if (lives <= 0)
            {
                GameData.playerScore += 500;
                GameData.brutes.Remove(this);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("GameEnd"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        rb.velocity = Vector2.zero;
        if(GameData.playerScore > GameData.highScore){
            GameData.highScore = GameData.playerScore;
        }
        SceneManager.LoadScene("GameOver");
    }
    public void TurnBlue() //colors need to be adjusted
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public void TurnWhite()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        // GetComponent<SpriteRenderer>().color = Color.white;
    }
}
