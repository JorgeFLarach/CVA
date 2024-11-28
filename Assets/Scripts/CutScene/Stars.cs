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

    void Start()
    {
        InvokeRepeating("SpawnStar", 0f, 0.5f);
        InvokeRepeating("SpawnPlanet", 0f, 8f);
    }

    void SpawnStar()
    {
        GameObject star = Instantiate(starPrefab,  GetRandomPosition(), Quaternion.identity);
    }

    void SpawnPlanet()
    {
        GameObject planet = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Length)],  GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(1, 5)-spawnOffsetX;
        float randomY = Random.Range(minY, maxY);
        return new Vector3(randomX, randomY, 0);
    }
}
