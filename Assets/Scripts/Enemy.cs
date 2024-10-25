using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{   
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    public float speed = 0.5f;
    public float lifeTime = 30f;

    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        Destroy(this.gameObject, lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameState gamestate = FindObjectOfType<GameState>();
        Destroy(this.gameObject); //Destory after use not BEFORE!!!!!!
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.velocity = direction * speed;

    }

}