using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Brute : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float lifeTime = 30f;
    public float lives = 10;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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

    public void GameOver()
    {
        rb.velocity = Vector2.zero;
        // Add additional game over logic here, such as displaying a game over screen
        SceneManager.LoadScene("GameOver");
    }
}
