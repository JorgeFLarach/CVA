using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaladFork : MonoBehaviour
{
  public int Speed;
  public int Damage;
  public Vector2 Target;
  public Vector2 Position;
  
  public int GetDamage(){
    return Damage;
  }
  public void SetDamage(int damage){
    Damage = damage;
  }
  /*public Quaternion findDirection(){*/
  /*  Vector2 direction = Target - Position;*/
  /*  float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;*/
  /*  return Quaternion.AngleAxis(angle, Vector3.forward);*/
  /*} */
  public void move(){
    transform.position = Vector2.MoveTowards(Position, Target, Speed * Time.deltaTime);

  }
  public void SetTarget(Vector2 target){
    Target = target;
  }
}
