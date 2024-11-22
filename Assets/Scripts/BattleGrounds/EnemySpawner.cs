using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Shooter shooterPrefab;
    public Brute brutePrefab;
    public float spawnDistance = 15f;
    public float spawnRate = 2f;
    public int spawnAmount = 1;
    public float trajectoryVariance = 15f;

    public int enemyCount = 0;

    public float waveTime = 60f;
    public int WaveCount = 1;

    public List<Enemy> enemies = new List<Enemy>();
    public List<Shooter> shooters = new List<Shooter>();
    public List<Brute> brutes = new List<Brute>();


    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        InvokeRepeating(nameof(SpawnShooter), spawnRate*10, spawnRate*5);
        InvokeRepeating(nameof(SpawnBrute), spawnRate*5, spawnRate*5);
    }

    public void Spawn()
    {

        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Vector3.left;
            Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Enemy enemy = Instantiate(enemyPrefab, spawnPoint, rotation);
            enemies.Add(enemy);
            enemyCount++;

            Vector2 trajectory = rotation * spawnDirection;
            enemy.SetTrajectory(trajectory);
        }

    }
    public void SpawnShooter()
    {
        Vector3 spawnDirection = Vector3.left;
        Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
        Shooter shooter = Instantiate(shooterPrefab, spawnPoint, Quaternion.identity);
        shooters.Add(shooter);
        enemyCount++;
    }
    public void SpawnBrute()
    {
        Vector3 spawnDirection = Vector3.left;
        Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
        Brute brute = Instantiate(brutePrefab, spawnPoint, Quaternion.identity);
        brutes.Add(brute);
        enemyCount++;


    }
    public void RemoveEnemy()
    {
        enemyCount--;
    }
    public bool AllEnemiesDead()
    {
        if(enemyCount <= 0){
            return true;
        }else{
            // Debug.Log("Enemies are still alive: " + enemies.Count);
            return false;
        }
    }

    private void Update()
    {
            waveTime -= Time.deltaTime;
        if (waveTime <= 0)
        {
            Debug.Log("Enemies are still alive: " + enemies.Count);
            CancelInvoke(nameof(Spawn));
            CancelInvoke(nameof(SpawnShooter));
            CancelInvoke(nameof(SpawnBrute));

            SceneManager.LoadScene("WaveScreen");
        }
        if(AllEnemiesDead()&& waveTime < 0)
        {
            // FindAnyObjectByType<GameSelector>().WaveCount++;
            SceneManager.LoadScene("WaveScreen");
        }
    }


}
