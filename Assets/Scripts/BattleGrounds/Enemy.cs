using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public float speed = 0.5f;
    public float lifeTime = 30f;
    public float lives = 3;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        Destroy(gameObject, lifeTime);

        // Set a random angle to move left
        float angle = Random.Range(-45f, 45f);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.left;
        SetTrajectory(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            lives--;
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("GameEnd")) // Replace "GameEndTag" with the actual tag
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
        // Add additional game over logic here, such as displaying a game over screen
        SceneManager.LoadScene("GameOver");
    }

}
