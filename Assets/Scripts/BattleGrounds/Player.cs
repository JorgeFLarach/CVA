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
  public SelectedFood selectedFood;
  public List<GameObject> saladSprites = new List<GameObject>();
  public List<GameObject> pieSprites = new List<GameObject>();
  public List<GameObject> lasangaSprites = new List<GameObject>();

  // private SelectedFood selectedFood;
  public Prefab saladPrefab;
  public Prefab piePrefab;
  public Prefab lasangaPrefab;

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
    GameObject salad = new GameObject();
    Instantiate(salad, position, Quaternion.identity);
    saladSprites.Add(salad);
  }
  public void ThrowPie(Vector2 position)
  {
    GameObject pie = new GameObject();
    Instantiate(pie, position, Quaternion.identity);
    pieSprites.Add(pie);
  }
  public void PlaceLasanga(Vector2 position)
  {
    GameObject lasanga = new GameObject();
    Instantiate(lasanga, position, Quaternion.identity);
    lasangaSprites.Add(lasanga);
  }
  public void PlaceFood(Vector2 position)
  {
    if(selectedFood.isSalad())
    {
      PlaceSalad(position);
    }
    else if(selectedFood.isPie())
    {
      ThrowPie(position);
    }
    else if (selectedFood.isLasanga()){
        PlaceLasanga(position);
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
}
