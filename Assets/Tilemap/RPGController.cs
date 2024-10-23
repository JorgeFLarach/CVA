using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RPGController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public Tilemap map;
    public Transform targetPosition;
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;

    private void Awake() {
        targetPosition.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < .01f && 
            !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, UnwalkableLayer)) {
                Collider2D g = Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, MoveableLayer);
                if (g) {
                    if(!(Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, UnwalkableLayer) ||
                        Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, MoveableLayer))) {
                        targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                        Debug.Log("setting based on double overlap");
                        Debug.Log(g.name);
                        g.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                    }
                    /*else {
                        Debug.Log("can't move. wall after block");
                    }*/
                } else {
                    targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                }
                //if (Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, MoveableLayer)) {
                //}
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        //if (Vector3.Distance(transform.position, targetPosition.position) < .01f) movement = Vector2.zero;
        //transform.Translate(Vector3.Normalize(movement) * speed * Time.deltaTime);
        //Debug.Log(map.GetSprite(map.WorldToCell(transform.position)));
    }

    void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
        if (movement.x != 0 && movement.y != 0) {
            movement = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            //other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
        }
    }
}
