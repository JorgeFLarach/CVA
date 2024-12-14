using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public static class GameData
{
    public static int highScore; 
    public static int playerScore;
    public static int waveNumber = 1;
    public static int globalFoodReserves = 500;
    public static float globalWaveTime = 120f;
    public static float globalTimeScale = 1.1f;
    public static bool freeze = false;
    public static bool burn = false;

    public static List<Table> tables = new List<Table>();
    public static List<Salad> saladLocations = new List<Salad>();
    public static List<Lasagna> lasagnaLocations = new List<Lasagna>();
    public static List<Pancakes> pancakesLocations = new List<Pancakes>();
    public static List<IceCream> icecreamLocations = new List<IceCream>();
    public static List<Salsa> salsaLocations = new List<Salsa>();
    public static List<Enemy> enemies = new List<Enemy>();
    public static List<Shooter> shooters = new List<Shooter>();
    public static List<Brute> brutes = new List<Brute>();
    public static List<Tomato> tomatos = new List<Tomato>();

    public static void SkipKitchenPrep(){
        globalFoodReserves += 240;
        SceneManager.LoadScene("Kitchen");
    }


    public static bool isOccupied(Vector2 position)
    {
        foreach (Salad salad in saladLocations)
        {
            if (salad.GetPosition() == position)
            {
                return true;
            }
        }
        foreach (Lasagna lasagna in lasagnaLocations)
        {
            if (lasagna.GetPosition() == position)
            {
                return true;
            }
        }
        foreach (Table table in tables)
        {
            if (table.GetPosition() == position)
            {
                return true;
            }
        }
        foreach (Pancakes pancakes in pancakesLocations)
        {
            if (pancakes.GetPosition() == position)
            {
                return true;
            }
        }
        foreach (IceCream icecream in icecreamLocations)
        {
            if (icecream.GetPosition() == position)
            {
                return true;
            }
        }
        foreach (Salsa salsa in salsaLocations)
        {
            if (salsa.GetPosition() == position)
            {
                return true;
            }
        }
        return false;
    }
    public static float makeDecimal(int wvNum)
    {
        return (float)wvNum / 10f;
    }
    public static void ClearFoodBoard()
    {
        saladLocations.Clear();
        lasagnaLocations.Clear();
        pancakesLocations.Clear();
        tables.Clear();
        enemies.Clear();
        shooters.Clear();
        brutes.Clear();
        tomatos.Clear();
        icecreamLocations.Clear();
        salsaLocations.Clear();
        ResetTime();
    }
    public static void ResetTime(){
        if (burn){
            burn = false;
            foreach (Tomato tomato in tomatos)
            {
                tomato.SetSpeed(3);
            }
            foreach (Salad salad in saladLocations)
            {
                salad.SetTimeScale(3);
            }
            TurnAllWhite();
        }
        if (freeze){
            globalTimeScale = (1 + makeDecimal(waveNumber));
            Time.timeScale = globalTimeScale;
            freeze = false;
            TurnAllWhite();
        }
    }
    public static void ResetGame()
    {
        ClearFoodBoard();
        globalFoodReserves = 500;
        globalWaveTime = 120f;
        globalTimeScale = 1.1f;
        waveNumber = 1;
        playerScore = 0;
        freeze = false;
        burn = false;
    }


    public static void setTimeScale(float scale)
    {
        globalTimeScale = scale;

    }

    public static void forkFood(Vector2 position)
    {
        List<Salad> saladRemoveList = new List<Salad>();
        List<Lasagna> lasagnaRemoveList = new List<Lasagna>();
        List<Pancakes> pancakesRemoveList = new List<Pancakes>();
        List<IceCream> iceCreamRemoveList = new List<IceCream>();
        List<Salsa> salsaRemoveList = new List<Salsa>();
        position = GridLockPosition(position);
        foreach (Salad salad in saladLocations)
        {
            if (salad.GetPosition() == position)
            {
                globalFoodReserves += 5;
                saladRemoveList.Add(salad);
            }
        }
        foreach (Lasagna lasagna in lasagnaLocations)
        {
            if (lasagna.GetPosition() == position)
            {
                globalFoodReserves += 2;
                lasagnaRemoveList.Add(lasagna);
            }
        }
        foreach (Pancakes pancakes in pancakesLocations)
        {
            if (pancakes.GetPosition() == position)
            {
                globalFoodReserves += 5;
                pancakesRemoveList.Add(pancakes);
            }
        }
        foreach (IceCream iceCream in icecreamLocations)
        {
            if (iceCream.GetPosition() == position)
            {
                globalFoodReserves += 10;
                iceCreamRemoveList.Add(iceCream);
            }
        }
        foreach (Salsa salsa in salsaLocations)
        {
            if (salsa.GetPosition() == position)
            {
                globalFoodReserves += 10;
                salsaRemoveList.Add(salsa);
            }
        }
        foreach (Salad salad in saladRemoveList)
        {
            salad.Die();
        }
        foreach (Lasagna lasagna in lasagnaRemoveList)
        {
            lasagna.Die();
        }
        foreach (Pancakes pancakes in pancakesRemoveList)
        {
            pancakes.Die();
        }
        foreach (IceCream iceCream in iceCreamRemoveList)
        {
            iceCream.Die();
        }
        foreach (Salsa salsa in salsaRemoveList)
        {
            salsa.Die();
        }
    }

    public static void AddFoodReserve(int amount)
    {
        globalFoodReserves += amount;
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
        return -5.55f;
    }

    public static Vector2 GridLockPosition(Vector2 input)
    {
        return new Vector2(
            LockXPosition(input.x),
            LockYPosition(input.y)
        );
    }
    public static void BurnEM(){
        TurnAllRed();
        foreach (Salad salad in saladLocations){
            // salad.TurnRed();
            salad.SetTimeScale(10f);
            foreach (Tomato tomato in tomatos){
                tomato.SetSpeed(10f);
            }
        }

    }


    public static void TurnAllBlue()
    {
        foreach (Salad salad in saladLocations)
        {
            salad.TurnBlue();
        }
        foreach (Lasagna lasagna in lasagnaLocations)
        {
            lasagna.TurnBlue();
        }
        foreach (Pancakes pancakes in pancakesLocations)
        {
            pancakes.TurnBlue();
        }
        foreach (IceCream iceCream in icecreamLocations)
        {
            iceCream.TurnBlue();
        }
        foreach (Enemy enemy in enemies)
        {
            enemy.TurnBlue();
        }
        foreach (Shooter shooter in shooters)
        {
            shooter.TurnBlue();
        }
        foreach (Brute brute in brutes)
        {
            brute.TurnBlue();
        }
        foreach (Salsa salsa in salsaLocations)
        {
            salsa.TurnBlue();
        }
        foreach (Tomato tomato in tomatos)
        {
            tomato.TurnBlue();
        }
    }
    public static void TurnAllWhite()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.TurnWhite();
        }
        foreach (Shooter shooter in shooters)
        {
            shooter.TurnWhite();
        }
        foreach (Brute brute in brutes)
        {
            brute.TurnWhite();
        }
        foreach (Salad salad in saladLocations)
        {
            salad.TurnWhite();
        }
        foreach (Lasagna lasagna in lasagnaLocations)
        {
            lasagna.TurnWhite();
        }
        foreach (Pancakes pancakes in pancakesLocations)
        {
            pancakes.TurnWhite();
        }
        foreach (IceCream iceCream in icecreamLocations)
        {
            iceCream.TurnWhite();
        }
        foreach (Salsa salsa in salsaLocations)
        {
            salsa.TurnWhite();
        }
        foreach (Tomato tomato in tomatos)
        {
            tomato.TurnWhite();
        }
    }
    public static void TurnAllRed()
    {
        foreach (Salad salad in saladLocations)
        {
            salad.TurnRed();
        }
        foreach (Lasagna lasagna in lasagnaLocations)
        {
            lasagna.TurnRed();
        }
        foreach (Pancakes pancakes in pancakesLocations)
        {
            pancakes.TurnRed();
        }
        foreach (IceCream iceCream in icecreamLocations)
        {
            iceCream.TurnRed();
        }
        foreach (Salsa salsa in salsaLocations)
        {
            salsa.TurnRed();
        }
        foreach (Tomato tomato in tomatos)
        {
            tomato.TurnRed();
        }
    }
}
