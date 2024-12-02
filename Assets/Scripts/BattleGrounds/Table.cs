using UnityEngine;

public class Table : MonoBehaviour
{
    private Vector2 Position;
    public Vector2 GetPosition(){
      return Position;
    }
    public void SetPosition(Vector2 position){
      Position = position;
    }
}
