using UnityEngine;

public class Ship : MonoBehaviour
{
    private float speed = 15f;
    public Vector2 pos;
    void Crash()
    {
    //south west till hit center
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    public bool Crashed(Vector2 input){
        if(pos == input){ // probably needs to be more broad
            return true;
        }else{
            return false;
        }

    }
}
