using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float blastSpeed = 10f;
    private float blastLifetime = 0.2f;

    private void Start()
    {
        Destroy(gameObject, blastLifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * blastSpeed * Time.deltaTime);
    }

    private float currentScale = 0.1f;
    private float maxScale = 5.0f;
    private float growthRate = 10.0f;

    private void FixedUpdate()
    {
        // Gradually increase scale
        if (currentScale < maxScale)
        {
            currentScale += growthRate * Time.fixedDeltaTime;
            transform.localScale = Vector3.one * currentScale;
        }
    }

}