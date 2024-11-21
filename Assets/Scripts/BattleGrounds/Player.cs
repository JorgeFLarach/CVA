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
  public SelectedFood selectedFood;
  public List<Salad> saladSprites = new List<Salad>();
  public List<Pie> pieSprites = new List<Pie>();
  public List<GameObject> lasangaSprites = new List<GameObject>();

  // private SelectedFood selectedFood;
  public Salad saladPrefab;
  public Pie piePrefab;
  // public Lasanga lasangaPrefab;

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
    // Lasanga lasanga = Instantiate(lasangaPrefab, position, Quaternion.identity);
    // lasangaSprites.Add(lasanga);
  }
  public int PlaceFood(Vector2 position)
  {
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


  void OnMouseDown()
  {
      // Get the position of the mouse click in world space
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = 0; // Set z to 0 since we're in 2D
      PlaceFood(mousePosition);
  }
}
