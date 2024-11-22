// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class Salad : MonoBehaviour
{
  public List<Tomato> tomatos = new List<Tomato>();
  private Vector2 Position;
  public int Health = 10;
  public Tomato tomatoPrefab;
  public int throwRate = 10;
  public int hp;

  public void SetPosition(Vector2 position){
    Position = position;
  }

  public void ThrowTomato(){
   Tomato tomato = Instantiate(tomatoPrefab, Position, Quaternion.identity);
   tomatos.Add(tomato);
  }
  public void SetHP(int num){
      hp = num;
  }

  public void TakeDamage(int damage){
    Health -= damage;
    if(Health <= 0){
      Die();
    }
  }
  public void Die(){
    Destroy(gameObject);
  }
  public void Start(){
    InvokeRepeating("ThrowTomato", 0, throwRate);
  }

  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger Entered");
        if (other.gameObject.CompareTag("Shot"))
        {
           TakeDamage(1);
        }
    }
}
