
using UnityEngine;

public class Lasanga : MonoBehaviour
{
    public float speed = 2f;
    public int lives = 3;
    public float Health = 10;

    private Vector2 Position;

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
        // transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void Start()
    {

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1 * Time.deltaTime); // Adjust damage over time
        }
    }
    public void TakeDamage(float damage){
      Health -= damage;
      if(Health <= 0){
        Die();
      }
    }
    public void Die(){
      Destroy(gameObject);
    }

}
