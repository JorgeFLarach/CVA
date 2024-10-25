using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 5f;
    public int lives = 3;

    void Update()
    {
        // Move the food to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
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

    void OnMouseDown()
    {
        // Get the position of the mouse click in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 since we're in 2D

        // Instantiate the food at the mouse position
        Instantiate(gameObject, mousePosition, Quaternion.identity);
    }
}