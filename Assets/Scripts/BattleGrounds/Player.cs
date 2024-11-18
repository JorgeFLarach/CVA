using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

struct SelectedFood
{
  bool salad;
  bool pie;
}
public class Player : MonoBehaviour
{
  public SelectedFood selectedFood;
  public Sprite[] saladSprites;
  public Sprite[] pieSprites;

  private SpriteRenderer spriteRenderer;
  private Rigidbody2D rb;

  public void PlaceSalad(Vector2 position)
  {
    GameObject salad = new GameObject();
    Instantiate(salad, position, Quaternion.identity);
    saladSprites.Add(salad);
  }
  public void ThrowPie()
  {
    GameObject pie = new GameObject();
    Instantiate(pie, position, Quaternion.identity);
    pieSprites.Add(pie);
  }
  public void PlaceFood(Vector2 position)
  {
    if(selectedFood.salad)
    {
      PlaceSalad(position);
    }
    else if(selectedFood.pie)
    {
      ThrowPie(position);
    }
  }
  public void SelectSalad()
  {
    selectedFood.salad = true;
    selectedFood.pie = false;
  }
  public void SelectPie()
  {
    selectedFood.salad = false;
    selectedFood.pie = true;
  }
}
