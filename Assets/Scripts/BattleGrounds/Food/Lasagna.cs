
using UnityEngine;

public class Lasagna : MonoBehaviour
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
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1 * Time.deltaTime);
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