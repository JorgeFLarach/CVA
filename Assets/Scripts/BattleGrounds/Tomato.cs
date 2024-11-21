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
  /*public Quaternion findDirection(){*/
  /*  Vector2 direction = Target - Position;*/
  /*  float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;*/
  /*  return Quaternion.AngleAxis(angle, Vector3.forward);*/
  /*} */
  public void move(){
    // transform.position = Vector2.MoveTowards(Position, Target, Speed);
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
          lives--; // Decrease lives by 1
          if (lives <= 0)
          {
              Destroy(gameObject); // Destroy the food if no lives are left
          }
      }
  }
}
