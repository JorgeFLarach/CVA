using UnityEngine;

public class Ship : MonoBehaviour
{
    private float speed = 15f;
    public Vector2 pos;
    public Blast blastPrefab;
    public GameObject brokenShipPrefab;
    void Update()
    {
        // Get screen center in world coordinates
        Vector2 screenCenter = new Vector2((Screen.width/2) + 100, Screen.height/2);
        Vector3 worldCenter = Camera.main.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, 0));
        worldCenter.z = transform.position.z; // Keep same z position
        
        // Get direction to center
        Vector3 direction = (worldCenter - transform.position).normalized;
        
        // Move towards center
        transform.Translate(direction * speed * Time.deltaTime);
        
        // Check if ship has reached center
        if (Vector3.Distance(transform.position, worldCenter) < 0.1f)
        {
            if (speed > 0f)  // Only spawn if we haven't stopped yet
            {
                SpawnBlast();
                speed = 0f;
                // Lock rotation when we spawn the blast
                enabled = false;  // This will disable the entire Update method
            }
            Destroy(gameObject);
            Instantiate(brokenShipPrefab, transform.position, transform.rotation);
        }
        
        // Rotate ship to face movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    public void SpawnBlast()
    {
        Blast blast = Instantiate(blastPrefab, transform.position, Quaternion.identity);
    }

}
