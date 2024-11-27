using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Shooter shooterPrefab;
    public Brute brutePrefab;
    public float spawnRate = 2f;
    public int spawnAmount = 1;
    public int enemyCount = 0;
    public float waveTime = 120f;
    public int WaveCount = 1;

    public List<Enemy> enemies = new List<Enemy>();
    public List<Shooter> shooters = new List<Shooter>();
    public List<Brute> brutes = new List<Brute>();

    public void SetWaveTime(float time)
    {
        waveTime = time;
    }
    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }
    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
    }

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        InvokeRepeating(nameof(SpawnShooter), spawnRate*10, spawnRate*5);
        InvokeRepeating(nameof(SpawnBrute), spawnRate*5, spawnRate*5);
    }
    public void endSpawning(){
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(SpawnShooter));
        CancelInvoke(nameof(SpawnBrute));
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, GridSpawning(), Quaternion.identity);
            enemies.Add(enemy);
        }
    }
    public Vector2 GridSpawning()
    {
        float rand = Random.Range(-4.8f, 4.2f);
        Vector2 position = new Vector2(4.95f, 0f);
        position.y = LockYPosition(rand);
        return position;
    }

    private float LockYPosition(float y)
    {
        if (y > 3.2f) return 3.7f;
        if (y > 2.2f) return 2.7f;
        if (y > 1.2f) return 1.7f;
        if (y > 0.2f) return 0.7f;
        if (y > -0.8f) return -0.3f;
        if (y > -1.8f) return -1.3f;
        if (y > -2.8f) return -2.3f;
        if (y > -3.8f) return -3.3f;
        return -4.3f;
    }

    public void SpawnShooter()
    {
        Shooter shooter = Instantiate(shooterPrefab, GridSpawning(), Quaternion.identity);
        shooters.Add(shooter);
    }
    public void SpawnBrute()
    {
        Brute brute = Instantiate(brutePrefab, GridSpawning(), Quaternion.identity);
        brutes.Add(brute);
    }
    public bool AllEnemiesDead()
    {
        return enemyCount <= 0;
    }

    public int updateEnemyCount(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    private void Update()
    {
        enemyCount = updateEnemyCount();
        waveTime -= Time.deltaTime;
        if (waveTime <= 0)
        {
            endSpawning();
            if(AllEnemiesDead())
            {
                GameData.waveNumber++;
                GameData.playerScore += 1000;
                SceneManager.LoadScene("WaveScreen");
        }
        }

    }


}
