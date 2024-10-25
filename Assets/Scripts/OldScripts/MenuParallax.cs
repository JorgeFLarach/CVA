using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float offsetMultiplier;
    public float effectAmount;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + (target.position * offsetMultiplier * effectAmount);
    }
}
