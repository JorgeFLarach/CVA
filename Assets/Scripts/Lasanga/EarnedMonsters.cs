using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EarnedMonsters : MonoBehaviour
{
    // Start is called before the first frame update
    public float lasagna;
    public float pie;
    public float veggie;

     public TMP_Text Monstertext;
    
    

    void Start()
    {
        lasagna = PlayerPrefs.GetInt("Lasagna", 0);
        pie = PlayerPrefs.GetInt("Pie", 0);
        veggie = PlayerPrefs.GetInt("Veggie", 0);
        Monstertext.text = $"Lasagna Monsters: {lasagna}\nPie Monsters: {pie}\n Veggie Monsters: {veggie} ";
        int total = (int)(lasagna + pie + veggie);
        int bonus = 100;
        GameData.AddFoodReserve(total+bonus);
        // Debug.Log($"Added {total} food to reserves");
    }

   
}
