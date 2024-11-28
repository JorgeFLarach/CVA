using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed = 2f;
    public int lifetime = 30;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
