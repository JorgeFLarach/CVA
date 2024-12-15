using UnityEngine;
using System;
using System.Collections.Generic;

public class chopped : MonoBehaviour
{
    public GameObject rightCabage;
    public GameObject leftCabage;
    public GameObject rightBokChoy;
    public GameObject leftBokChoy;
    public GameObject rightBrusselSprout;
    public GameObject leftBrusselSprout;
    public GameObject rightTomato;
    public GameObject leftTomato;

    public void chopCabbage(Vector2 pos){
        Instantiate(rightCabage, pos, Quaternion.identity);
        Instantiate(leftCabage, pos, Quaternion.identity);
    }
    public void chopBokChoy(Vector2 pos){
        Instantiate(rightBokChoy, pos, Quaternion.identity);
        Instantiate(leftBokChoy, pos, Quaternion.identity);
    }
    public void chopBrusselSprout(Vector2 pos){
        Instantiate(rightBrusselSprout, pos, Quaternion.identity);
        Instantiate(leftBrusselSprout, pos, Quaternion.identity);
    }
    public void chopTomato(Vector2 pos){
        Instantiate(rightTomato, pos, Quaternion.identity);
        Instantiate(leftTomato, pos, Quaternion.identity);
    }
}
