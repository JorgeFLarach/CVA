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
    public void SetDamage(int dmg){
        damage = dmg;
    }
    public void SetHP(int num){
        hp = num;
    }

    void Update()
    {
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
            lives--;
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger Entered");
        if (other.gameObject.CompareTag("Shot"))
        {
            lives--; // Decrease lives by 1
            if (lives <= 0)
            {
                Destroy(gameObject); // Destroy the food if no lives are left
            }
        }
    }

}
