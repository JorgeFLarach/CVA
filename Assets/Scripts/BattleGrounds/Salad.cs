// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class Salad : MonoBehaviour
{
  public List<SaladFork> forks = new List<SaladFork>();
  public Vector2 Position;
  public int Health;
  public SaladFork forkPrefab;

  public Targeting targeting;

  public void ThrowFork(){
   GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");
   Vector3 closestPosition = targeting.GetClosestTargetPosition(potentialTargets);
   SaladFork fork = Instantiate(forkPrefab, Position, Quaternion.identity);
   fork.GetComponent<SaladFork>().SetTarget(closestPosition); 
   forks.Add(fork);
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
