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
        food = "lasanga";
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
    public void lasanga(){
        food = "lasanga";
    }
    public bool isSalad(){
        return food == "salad";
    }
    public bool isPie(){
        return food == "pie";
    }
    public bool isLasanga(){
        return food == "lasanga";
    }
}

public class Player : MonoBehaviour
{
    public int pieCost = 1;
    public int saladCost = 10;
    public int lasangaCost = 5;
    public int pieHP;
    public int tomatoHP;
    public int saladHP;
    public int lasangaHP;
    public int pieDmg;
    public int tomatoDmg;

    public SelectedFood selectedFood;
    public List<Salad> saladSprites = new List<Salad>();
    public List<Pie> pieSprites = new List<Pie>();
    public List<Lasanga> lasangaSprites = new List<Lasanga>();

    public Salad saladPrefab;
    public Pie piePrefab;
    public Lasanga lasangaPrefab;

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
            lasangaHP = hp;
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
            lasangaCost = cost;
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
            SelectLasanga();
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
    public void SelectLasanga()
    {
        selectedFood.lasanga();
    }

    public void PlaceSalad(Vector2 position)
    {
        Salad salad = Instantiate(saladPrefab, position, Quaternion.identity);
        salad.SetPosition(position);
        saladSprites.Add(salad);
    }
    public void ThrowPie(Vector2 position)
    {
        Pie pie = Instantiate(piePrefab, position, Quaternion.identity);
        pieSprites.Add(pie);
    }
    public void PlaceLasanga(Vector2 position)
    {
        Lasanga lasanga = Instantiate(lasangaPrefab, position, Quaternion.identity);
        lasangaSprites.Add(lasanga);
    }
    public int PlaceFood(Vector2 input)
    {
        Vector2 position = CalculatePosition(input);
        if(selectedFood.isSalad())
        {
            PlaceSalad(position);
            return saladCost;
        }
        else if(selectedFood.isPie())
        {
            ThrowPie(position);
            return pieCost;
        }
        else if (selectedFood.isLasanga()){
            PlaceLasanga(position);
            return lasangaCost;
        } else {
            return 0;
        }
    }


    public Vector2 CalculatePosition(Vector2 input)
    {
        Vector2 position = new Vector2(input.x, input.y);
        if (input.y > 3.2f) {
            position.y = 3.7f;
        } else if (input.y > 2.2f) {
            position.y = 2.7f;
        } else if (input.y > 1.2f) {
            position.y = 1.7f;
        } else if (input.y > 0.2f) {
            position.y = 0.7f;
        } else if (input.y > -0.8f) {
            position.y = -0.3f;
        } else if (input.y > -1.8f) {
            position.y = -1.3f;
        } else if (input.y > -2.8f) {
            position.y = -2.3f;
        } else if (input.y > -3.8f) {
            position.y = -3.3f;
        } else {
            position.y = -4.3f;
        }
        if (input.x > -6.3f && input.x <= -4.8f) {
            position.x = -5.55f;
        } else if (input.x > -4.8f && input.x <= -3.3f) {
            position.x = -4.05f;
        } else if (input.x > -3.3f && input.x <= -1.8f) {
            position.x = -2.55f;
        } else if (input.x > -1.8f && input.x <= -0.3f) {
            position.x = -1.05f;
        } else if (input.x > -0.3f && input.x <= 1.2f) {
            position.x = 0.45f;
        } else if (input.x > 1.2f && input.x <= 2.7f) {
            position.x = 1.95f;
        } else if (input.x > 2.7f && input.x <= 4.2f) {
            position.x = 3.45f;
        } else if (input.x > 4.2f && input.x <= 5.7f) {
            position.x = 4.95f;
        } else {
            position.x = -6.3f;
        }
        return position;
    }
}
