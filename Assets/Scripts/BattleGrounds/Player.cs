using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedFood
{
    public string food;

    public void SetFood(int num)
    {
        if (num == 1)
        {
            food = "salad";
        }
        else if (num == 2)
        {
            food = "pie";
        }
        else if (num == 3)
        {
            food = "lasagna";
        }
        else if (num == 4)
        {
            food = "pancakes";
        }
        else if (num == 5)
        {
            food = "icecream";
        }
    }
    public string GetFood()
    {
        return food;
    }
    public void salad()
    {
        food = "salad";
    }
    public void pie()
    {
        food = "pie";
    }
    public void lasagna()
    {
        food = "lasagna";
    }
    public bool isSalad()
    {
        return food == "salad";
    }
    public bool isPie()
    {
        return food == "pie";
    }
    public bool isLasagna()
    {
        return food == "lasagna";
    }
    public bool isPancakes()
    {
        return food == "pancakes";
    }
    public void pancakes()
    {
        food = "pancakes";
    }
    public void icecream()
    {
        food = "icecream";
    }
    public bool isIcecream()
    {
        return food == "icecream";
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
    public int pancakesCost = 10;
    public int iceCreamCost = 15;

    public SelectedFood selectedFood;
    public List<Salad> saladSprites = new List<Salad>();
    public List<Pie> pieSprites = new List<Pie>();
    public List<Lasagna> lasagnaSprites = new List<Lasagna>();
    public List<Pancakes> pancakesSprites = new List<Pancakes>();


    public Salad saladPrefab;
    public Pie piePrefab;
    public Lasagna lasagnaPrefab;
    public Pancakes pancakesPrefab;
    public IceCream iceCreamPrefab;
    public Table tablePrefab;
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
        // PlaceFoodWithKey();
    }

    public void SetHP(int num, int hp)
    {
        if (num == 1)
        {
            pieHP = hp;
        }
        else if (num == 2)
        {
            tomatoHP = hp;
        }
        else if (num == 3)
        {
            saladHP = hp;
        }
        else if (num == 4)
        {
            lasagnaHP = hp;
        }
    }
    public void SetCost(int num, int cost)
    {
        if (num == 1)
        {
            pieCost = cost;
        }
        else if (num == 2)
        {
            saladCost = cost;
        }
        else if (num == 3)
        {
            lasagnaCost = cost;
        }
        else if (num == 4)
        {
            pancakesCost = cost;
        }
        else if (num == 5)
        {
            iceCreamCost = cost;
        }
    }
    public void SetDmg(int num, int dmg)
    {
        if (num == 1)
        {
            pieDmg = dmg;
        }
        else if (num == 2)
        {
            tomatoDmg = dmg;
        }
    }

    // public void PlaceFoodWithKey(){
    //     if(Input.GetKeyDown(KeyCode.Alpha1)){
    //         SelectPie();
    //     }

    //     if(Input.GetKeyDown(KeyCode.Alpha2)){
    //         SelectSalad();
    //     }

    //     if(Input.GetKeyDown(KeyCode.Alpha3)){
    //         SelectLasagna();
    //     }

    //     if(Input.GetKeyDown(KeyCode.Alpha4)){
    //         SelectPancakes();
    //     }
    // }

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
    public void SelectPancakes()
    {
        selectedFood.pancakes();
    }
    public void SelectIceCream()
    {
        selectedFood.icecream();
    }
    public void PlaceTable(Vector2 position)
    {
        Table table = Instantiate(tablePrefab, position, Quaternion.identity);
        table.SetPosition(position);
        GameData.tables.Add(table);
    }

    public void PlaceSalad(Vector2 position)
    {
        Salad salad = Instantiate(saladPrefab, position, Quaternion.identity);
        salad.SetPosition(position);
        // saladSprites.Add(salad);
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
        lasagna.SetPosition(position);
        // lasagnaSprites.Add(lasagna);
        GameData.lasagnaLocations.Add(lasagna);
    }
    public void PlacePancakes(Vector2 position)
    {
        Pancakes pancakes = Instantiate(pancakesPrefab, position, Quaternion.identity);
        pancakes.SetPosition(position);
        // pancakesSprites.Add(pancakes);
        GameData.pancakesLocations.Add(pancakes);
    }
    public void PlaceIceCream(Vector2 position)
    {
        IceCream iceCream = Instantiate(iceCreamPrefab, position, Quaternion.identity);
        iceCream.SetPosition(position);
        GameData.icecreamLocations.Add(iceCream);
    }
    public int PlaceFood(Vector2 input)
    {
        if (input.x > 5.7f || input.x < -6.3f)
        {
            return 0;
        }
        Vector2 position = GameData.GridLockPosition(input);
        if (selectedFood.isSalad() && !GameData.isOccupied(position))
        {
            PlaceSalad(position);
            return saladCost;
        }
        else if (selectedFood.isLasagna() && !GameData.isOccupied(position))
        {
            PlaceLasagna(position);
            return lasagnaCost;
        }
        else if (selectedFood.isPancakes() && !GameData.isOccupied(position))
        {
            PlacePancakes(position);
            return 0;
        }
        else if (selectedFood.isPie())
        {
            ThrowPie(position);
            return pieCost;
        }
        else if (selectedFood.isIcecream() && !GameData.isOccupied(position))
        {
            PlaceIceCream(position);
            return iceCreamCost;
        }
        else
        {
            return 0;
        }
    }

}
