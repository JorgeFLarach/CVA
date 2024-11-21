using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnDistance = 15f;
    public float spawnRate = 2f;
    public int spawnAmount = 1;
    public float trajectoryVariance = 15f;

    public int enemyCount = 0;

    public float waveTime = 60f;
    public int WaveCount = 1;

    public List<Enemy> enemies = new List<Enemy>();


    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
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

            SceneManager.LoadScene("WaveScreen");
        }
        if(AllEnemiesDead()&& waveTime < 0)
        {
            // FindAnyObjectByType<GameSelector>().WaveCount++;
            SceneManager.LoadScene("WaveScreen");
        }
    }


}
