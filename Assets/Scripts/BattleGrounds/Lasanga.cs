
using UnityEngine;

public class Lasagna : MonoBehaviour
{
    public float speed = 2f;
    public int lives = 3;

    private Vector2 Position;

    public int lifetime = 30;
    public int hp;

    public void SetHP(int num){
        hp = num;
    }

    public void SetPosition(Vector2 position){
      Position = position;
    }

    void Update()
    {
        // Move the food to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--; // Decrease lives by 1
            if (lives <= 0)
            {
                Destroy(gameObject); // Destroy the food if no lives are left
            }
        }
    }
}
