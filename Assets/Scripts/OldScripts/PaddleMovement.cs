using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    private Vector2 mousePos;
    private bool needsBounce = false;
    public Vector2 newVelo;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(mousePos.x,transform.position.y);
    }

        void FixedUpdate()
    {
        if (needsBounce) {
            ball.GetComponent<Rigidbody2D>().velocity = newVelo;
            needsBounce = false;
        }
    }

    void OnMove(InputValue value) {
        //Debug.Log(value.Get<Vector2>());
        Vector2 input = value.Get<Vector2>();
        if (input.x > 100 && input.x < Screen.width - 100)
            mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

        private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            needsBounce = true;

            newVelo = other.relativeVelocity /* * Vector2.up*/ * -1f;
            ContactPoint2D contact = other.GetContact(0);
            Vector2 paddlePt = contact.point - new Vector2(transform.position.x,transform.position.y);
            newVelo.x = paddlePt.x * 4f;
            newVelo = newVelo.normalized * 8f;
        }
    }
}
