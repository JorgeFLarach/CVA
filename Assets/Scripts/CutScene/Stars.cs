using UnityEngine;

public class Stars : MonoBehaviour
{
    public int starCount = 100;
    public GameObject starPrefab;
    public GameObject[] planetPrefabs;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float spawnOffsetX = 15f;
    public float minY = -10f;
    public float maxY = 10f;
    public int planetsEvery = 10;

    public float speedUpVal = 10f;

    void Start()
    {
        InvokeRepeating("SpawnStar", 0f, 0.1f);
        InvokeRepeating("SpawnPlanet", 0f, 4f);
    }

    void SpawnStar()
    {
        GameObject star = Instantiate(starPrefab,  GetRandomPosition(), Quaternion.identity);
        // star.SpeedUp(speedUpVal);
    }

    void SpawnPlanet()
    {
        GameObject planet = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Length)],  GetRandomPosition(), Quaternion.identity);
        // planet.SpeedUp(speedUpVal);
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(1, 5)-spawnOffsetX;
        float randomY = Random.Range(minY, maxY);
        return new Vector3(randomX, randomY, 0);
    }
}
