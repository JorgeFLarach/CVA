using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float minX,maxX;
    public float range;
    private bool isFacingRight = true;
    public float mSpeed;
    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x - range;
        maxX = transform.position.x + range;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.right * mSpeed * Time.deltaTime);
        if (isFacingRight && transform.position.x > maxX) Flip();
        if (!isFacingRight && transform.position.x < minX) Flip();
    }

    private void Flip() {
        Debug.Log("Flipping");
        isFacingRight = !isFacingRight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        /*Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;*/
    }
}
