using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private int hitsLeft = 2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Hit");
        if (hitsLeft <= 0) Destroy(gameObject);
        hitsLeft--;
        anim.SetInteger("BlockHitsLeft",hitsLeft);
    }
}
