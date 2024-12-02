using UnityEngine;
using System.Collections.Generic;
public static class GameData
{
    public static int highScore;
    public static int playerScore;
    public static int waveNumber = 1;
    public static int globalFoodReserves = 500;


    public static List <Salad> saladLocations = new List<Salad>();
    public static List <Lasagna> lasagnaLocations = new List<Lasagna>();
    public static bool isOccupied(Vector2 position){
        foreach(Salad salad in saladLocations){
            if(salad.Position == position){
                return true;
            }
        }
        foreach(Lasagna lasagna in lasagnaLocations){
            if(lasagna.Position == position){
                return true;
            }
        }
        return false;
    }

    public static void Reset(){
        playerScore = 0;
        waveNumber = 1;
        globalFoodReserves = 500;
    }
}
