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
    public TMP_Text veggieText;
    public TMP_Text pieText;
    public TMP_Text lasagnaText;
    public TMP_Text totalText;
    public TMP_Text waveNumber;

    void Start(){
        lasagna = PlayerPrefs.GetInt("Lasagna", 0);
        pie = PlayerPrefs.GetInt("Pie", 0);
        veggie = PlayerPrefs.GetInt("Veggie", 0);
        lasagnaText.text = $"{lasagna}";
        veggieText.text = $"{veggie}";
        pieText.text = $"{pie}";
        int total = (int)(lasagna + pie + veggie);
        int bonus = 100;
        int foodReserves = total+bonus;
        totalText.text = $"{total}";
        GameData.AddFoodReserve(foodReserves);
        waveNumber.text = $"Get Ready for Wave {GameData.waveNumber}";
        // Debug.Log($"Added {total} food to reserves");
    }


}
