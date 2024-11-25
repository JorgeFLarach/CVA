using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 2f;
    public int lives = 3;

    public int lifetime = 30;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
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

    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(gameObject, mousePosition, Quaternion.identity);
    }
}
