using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed = 0.5f;
    public float lifeTime = 30f;
    public float lives = 3;
    public SpriteRenderer spriteRenderer;

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

            GameData.playerScore += 100;
            speed = 0;
            spriteRenderer.color = new Color(0.6f, 0.4f, 0.2f, 1f); // Brown color

        }
        if (collision.gameObject.CompareTag("Food"))
        {
            lives--;
            if (lives <= 0)
            {
                GameData.playerScore += 100;
                GameData.enemies.Remove(this);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("GameEnd"))
        {
            GameOver();
        }
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void GameOver()
    {
        rb.velocity = Vector2.zero;
        if(GameData.playerScore > GameData.highScore){
            GameData.highScore = GameData.playerScore;
        }
        SceneManager.LoadScene("GameOver");
    }
    public void TurnBlue()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public void TurnRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void TurnWhite()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
