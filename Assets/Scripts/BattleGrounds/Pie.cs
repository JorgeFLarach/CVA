using UnityEngine;

public class Pie : MonoBehaviour
{
    public float speed = 2f;
    public int lives = 1;
    public int damage = 10;
    public int hp;

    public int lifetime = 30;

    public int GetDamage(){
      return damage;
    }
    public void SetHP(int num){
        hp = num;
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
