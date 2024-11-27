using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tomato : MonoBehaviour
{
  public int speed = 1;
  public int hp;

  public int damage = 2;
  public Vector2 Target;
  public Vector2 Position;
  public int lives = 1;
  public int GetDamage(){
    return damage;
  }
  public void SetHP(int num){
      hp = num;
  }
  public void SetDamage(int dmg){
    damage = dmg;
  }
  public void move(){
    transform.Translate(Vector3.right * speed * Time.deltaTime);

  }
  public void Update(){
    move();
  }
  public void SetTarget(Vector2 target){
    Target = target;
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
}
