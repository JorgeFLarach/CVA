// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class Salad : MonoBehaviour
{
  public List<Tomato> tomatos = new List<Tomato>();
  public Vector2 Position;
  public int Health;
  public Tomato tomatoPrefab;

  public Targeting targeting;

  public void ThrowTomato(){
   GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");
   Vector3 closestPosition = targeting.GetClosestTargetPosition(potentialTargets);
   Tomato tomato = Instantiate(tomatoPrefab, Position, Quaternion.identity);
   tomato.GetComponent<Tomato>().SetTarget(closestPosition);
   tomatos.Add(tomato);
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
    targeting = GetComponent<Targeting>();
  }
}
