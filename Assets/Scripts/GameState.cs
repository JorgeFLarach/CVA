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

    
}
