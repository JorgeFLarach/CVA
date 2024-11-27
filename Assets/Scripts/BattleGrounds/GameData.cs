using UnityEngine;

public static class GameData
{
    public static int highScore;
    public static int playerScore;
    public static int waveNumber = 1;
    public static int globalFoodReserves = 500;


    // public static void saveHighScore(){
    //     if(playerScore > highScore){
    //         highScore = playerScore;
    //         string filePath = Application.persistentDataPath + "/highscore.txt";
    //         System.IO.File.WriteAllText(filePath, highScore.ToString());
    //     }
    // }
    // public static void loadHighScore(){
    //     string filePath = Application.persistentDataPath + "/highscore.txt";
    //     if(System.IO.File.Exists(filePath)){
    //         highScore = int.Parse(System.IO.File.ReadAllText(filePath));
    //     }
    // }
    // public static void Update(){
    //     saveHighScore();
    // }

    public static void Reset(){
        playerScore = 0;
        waveNumber = 1;
        globalFoodReserves = 500;
    }
}
