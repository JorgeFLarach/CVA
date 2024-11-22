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

  public SelectedFood selectedFood;
  public List<Salad> saladSprites = new List<Salad>();
  public List<Pie> pieSprites = new List<Pie>();
  public List<Lasanga> lasangaSprites = new List<Lasanga>();

  // private SelectedFood selectedFood;
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


  public Vector2 CalculatePosition(Vector2 input){
    Vector2 position = new Vector2(input.x, input.y);
    if(input.y > 3.2){
        Debug.Log("y set to 3.7");
        position.y = 3.7f;
    }else if(input.y <3.2 && input.y > 2.2){
        Debug.Log("y set to 2.7");
        position.y = 2.7f;
    }else if(input.y <2.2 && input.y > 1.2){
        Debug.Log("y set to 1.7");
        position.y = 1.7f;
    }else if(input.y <1.2 && input.y > 0.2){
        Debug.Log("y set to 0.7");
        position.y = 0.7f;
    }else if(input.y <0.2 && input.y > -0.8){
        Debug.Log("y set to -0.3");
        position.y = -0.3f;
    }else if(input.y < -0.8 && input.y > -1.8){
        Debug.Log("y set to -1.3");
        position.y = -1.3f;
    }else if(input.y < -1.8 && input.y > -2.8){
        Debug.Log("y set to -2.3");
        position.y = -2.3f;
    }else if(input.y < -2.8 && input.y > -3.8){
        Debug.Log("y set to -3.3");
        position.y = -3.3f;
    }else {
        Debug.Log("y set to -4.3");
        position.y = -4.3f;
    }
    Debug.Log("position.y: " + position.y);

    if (input.x > -6.3 && input.x <= -4.8)
        {
            Debug.Log("x set to -5.55");
            position.x = -5.55f;
        }
        else if (input.x > -4.8 && input.x <= -3.3)
        {
            Debug.Log("x set to -4.05");
            position.x = -4.05f;
        }
        else if (input.x > -3.3 && input.x <= -1.8)
        {
            Debug.Log("x set to -2.55");
            position.x = -2.55f;
        }
        else if (input.x > -1.8 && input.x <= -0.3)
        {
            Debug.Log("x set to -1.05");
            position.x = -1.05f;
        }
        else if (input.x > -0.3 && input.x <= 1.2)
        {
            Debug.Log("x set to 0.45");
            position.x = 0.45f;
        }
        else if (input.x > 1.2 && input.x <= 2.7)
        {
            Debug.Log("x set to 1.95");
            position.x = 1.95f;
        }
        else if (input.x > 2.7 && input.x <= 4.2)
        {
            Debug.Log("x set to 3.45");
            position.x = 3.45f;
        }
        else if (input.x > 4.2 && input.x <= 5.7)
        {
            Debug.Log("x set to 4.95");
            position.x = 4.95f;
        }
        else
        {
            Debug.Log("x is out of bounds, defaulting to -6.3");
            position.x = -6.3f; // Default or out-of-bounds handling
        }

        Debug.Log("position.x: " + position.x);
        return position;
  }
  public void SelectSalad()
  {
    Debug.Log("salad selected");
    selectedFood.salad();
  }
  public void SelectPie()
  {
    Debug.Log("pie selected");
    selectedFood.pie();
  }
  public void SelectLasanga()
  {
    selectedFood.lasanga();
  }
  public void Update()
  {
    PlaceFoodWithKey();
  }
}
