using UnityEngine;

public class Pancakes : MonoBehaviour
{
    private Vector2 Position;

    public Vector2 GetPosition(){
      return Position;
    }
    public void SetPosition(Vector2 position){
      Position = position;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die(){
      GameData.pancakesLocations.Remove(this);
      Destroy(gameObject);
    }

}
