using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedFood
{
    public string food;

    public void SetFood(int num){
        if(num == 1){
        food = "salad";
        }
        else if(num == 2){
        food = "pie";
        }
        else if(num == 3){
        food = "lasagna";
        }
    }
    public string GetFood(){
        return food;
    }
    public void salad(){
        food = "salad";
    }
    public void pie(){
        food = "pie";
    }
    public void lasagna(){
        food = "lasagna";
    }
    public bool isSalad(){
        return food == "salad";
    }
    public bool isPie(){
        return food == "pie";
    }
    public bool isLasagna(){
        return food == "lasagna";
    }
}

public class Player : MonoBehaviour
{
    public int pieCost = 1;
    public int saladCost = 10;
    public int lasagnaCost = 5;
    public int pieHP;
    public int tomatoHP;
    public int saladHP;
    public int lasagnaHP;
    public int pieDmg;
    public int tomatoDmg;

    public SelectedFood selectedFood;
    public List<Salad> saladSprites = new List<Salad>();
    public List<Pie> pieSprites = new List<Pie>();
    public List<Lasagna> lasagnaSprites = new List<Lasagna>();

    public Salad saladPrefab;
    public Pie piePrefab;
    public Lasagna lasagnaPrefab;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public void Start()
    {
        selectedFood = new SelectedFood();
        selectedFood.pie();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        PlaceFoodWithKey();
    }

    public void SetHP(int num, int hp){
        if(num == 1){
            pieHP = hp;
        }
        else if(num == 2){
            tomatoHP = hp;
        }
        else if(num == 3){
            saladHP = hp;
        }
        else if(num == 4){
            lasagnaHP = hp;
        }
    }
    public void SetCost(int num, int cost){
        if(num == 1){
            pieCost = cost;
        }
        else if(num == 2){
            saladCost = cost;
        }
        else if(num == 3){
            lasagnaCost = cost;
        }
    }
    public void SetDmg(int num, int dmg){
        if(num == 1){
            pieDmg = dmg;
        }
        else if(num == 2){
            tomatoDmg = dmg;
        }
    }

    public void PlaceFoodWithKey(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SelectPie();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SelectSalad();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            SelectLasagna();
        }
    }

    public void SelectSalad()
    {
        selectedFood.salad();
    }
    public void SelectPie()
    {
        selectedFood.pie();
    }
    public void SelectLasagna()
    {
        selectedFood.lasagna();
    }

    public void PlaceSalad(Vector2 position)
    {
        Salad salad = Instantiate(saladPrefab, position, Quaternion.identity);
        salad.SetPosition(position);
        saladSprites.Add(salad);
        GameData.saladLocations.Add(salad);
    }
    public void ThrowPie(Vector2 position)
    {
        Pie pie = Instantiate(piePrefab, position, Quaternion.identity);
        pieSprites.Add(pie);
    }
    public void PlaceLasagna(Vector2 position)
    {
        Lasagna lasagna = Instantiate(lasagnaPrefab, position, Quaternion.identity);
        lasagnaSprites.Add(lasagna);
        GameData.lasagnaLocations.Add(lasagna);
    }
    public int PlaceFood(Vector2 input)
    {
        Vector2 position = GridLockPosition(input);
        if(selectedFood.isSalad() && !GameData.isOccupied(position))
        {
            PlaceSalad(position);
            return saladCost;
        }
        else if(selectedFood.isPie())
        {
            ThrowPie(position);
            return pieCost;
        }
        else if (selectedFood.isLasagna() && !GameData.isOccupied(position)){
            PlaceLasagna(position);
            return lasagnaCost;
        } else {
            return 0;
        }
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

    private float LockXPosition(float x)
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

    public Vector2 GridLockPosition(Vector2 input)
    {
        return new Vector2(
            LockXPosition(input.x),
            LockYPosition(input.y)
        );
    }
}
