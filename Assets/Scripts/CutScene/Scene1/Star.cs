using UnityEngine;

public class Star : MonoBehaviour
{
    private float speed = 15f;
    private int lifetime = 2;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SpeedUp(float input)
    {
         speed = input;
    }
}
