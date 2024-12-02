using UnityEngine;
using System.Collections.Generic;
public static class GameData
{
    public static int highScore;
    public static int playerScore;
    public static int waveNumber = 1;
    public static int globalFoodReserves = 500;

    public static List<Table> tables = new List<Table>();
    public static List <Salad> saladLocations = new List<Salad>();
    public static List <Lasagna> lasagnaLocations = new List<Lasagna>();
    public static bool isOccupied(Vector2 position){
        foreach(Salad salad in saladLocations){
            if(salad.GetPosition() == position){
                return true;
            }
        }
        foreach(Lasagna lasagna in lasagnaLocations){
            if(lasagna.GetPosition() == position){
                return true;
            }
        }
        foreach(Table table in tables){
            if(table.GetPosition() == position){
                return true;
            }
        }
        return false;
    }
    public static void ClearFoodBoard(){
        saladLocations.Clear();
        lasagnaLocations.Clear();
        tables.Clear();
    }

    public static void AddFoodReserve(int amount){
        globalFoodReserves += amount;
    }

    public static void Reset(){
        playerScore = 0;
        waveNumber = 1;
        globalFoodReserves = 500;
    }

    public static float LockYPosition(float y)
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

    public static float LockXPosition(float x)
    {
        if (x > -6.3f && x <= -4.8f) return -5.55f;
        if (x > -4.8f && x <= -3.3f) return -4.05f;
        if (x > -3.3f && x <= -1.8f) return -2.55f;
        if (x > -1.8f && x <= -0.3f) return -1.05f;
        if (x > -0.3f && x <= 1.2f) return 0.45f;
        if (x > 1.2f && x <= 2.7f) return 1.95f;
        if (x > 2.7f && x <= 4.2f) return 3.45f;
        if (x > 4.2f && x <= 5.7f) return 4.95f;
        return -6.3f;
    }

    public static Vector2 GridLockPosition(Vector2 input)
    {
        return new Vector2(
            LockXPosition(input.x),
            LockYPosition(input.y)
        );
    }
}
