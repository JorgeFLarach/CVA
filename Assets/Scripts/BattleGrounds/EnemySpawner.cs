using System.Collections;
using System.Collections.Generic;
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
            Enemy enemy = Instantiate(enemyPrefab, GridSpawning(), Quaternion.identity);
            enemies.Add(enemy);
            // enemyCount++;
        }

    }
    public Vector2 GridSpawning(){
        float rand = Random.Range(-4.8f,4.2f);
        Vector2 position = new Vector2(4.95f, 0f);
        if(rand > 3.2f){
            position.y = 3.7f;
        }else if(rand <3.2f && rand > 2.2f){
            position.y = 2.7f;
        }else if(rand <2.2f && rand > 1.2f){
            position.y = 1.7f;
        }else if(rand <1.2f && rand > 0.2f){
            position.y = 0.7f;
        }else if(rand <0.2f && rand > -0.8f){
            position.y = -0.3f;
        }else if(rand < -0.8f && rand > -1.8f){
            position.y = -1.3f;
        }else if(rand < -1.8f && rand > -2.8f){
            position.y = -2.3f;
        }else if(rand < -2.8f && rand > -3.8f){
            position.y = -3.3f;
        }else {
            position.y = -4.3f;
        }
        return position;
    }

    public void SpawnShooter()
    {
        Vector3 spawnDirection = Vector3.left;
        Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
        Shooter shooter = Instantiate(shooterPrefab, GridSpawning(), Quaternion.identity);
        shooters.Add(shooter);
    }
    public void SpawnBrute()
    {
        Vector3 spawnDirection = Vector3.left;
        Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
        Brute brute = Instantiate(brutePrefab, GridSpawning(), Quaternion.identity);
        brutes.Add(brute);
    }
    public void RemoveEnemy()
    {
        enemyCount--;
    }
    public bool AllEnemiesDead()
    {
        return enemyCount <= 0;
    }
    public void endSpawning(){
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(SpawnShooter));
        CancelInvoke(nameof(SpawnBrute));
    }

    public int updateEnemyCount(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    private void Update()
    {
        enemyCount = updateEnemyCount();
        // Debug.Log(enemyCount);
        waveTime -= Time.deltaTime;
        if (waveTime <= 0)
        {
            endSpawning();
            if(AllEnemiesDead())
            {
                SceneManager.LoadScene("WaveScreen");
        }
        }

    }


}
