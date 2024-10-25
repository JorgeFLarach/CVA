using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public int score = 0;

    public void AddScore(int score)
    {
        this.score += score;
    }
    public GameObject foodPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f; // Set this to be the distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Instantiate(foodPrefab, worldPosition, Quaternion.identity);
    }

}
