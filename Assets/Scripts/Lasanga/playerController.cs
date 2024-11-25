using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;



public class playerController : MonoBehaviour
{
    public bool fstMove = true;
    public InputAction playerControls;
    public float speed = 5.3f;
    public Animator anim;
    public Vector2 moveDir;
    //public TMP_Text timeText;

    public float timer;
    public Rigidbody2D rb;
    public void Start()
    {
        playerControls.Enable();
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    
    }

    public void Update(){
      timer = PlayerPrefs.GetFloat("Timer");
        if (timer > 0){
            moveDir = playerControls.ReadValue<Vector2>();
        }

   
    }

    public void FixedUpdate(){
       rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

       if(Input.GetKey("right")){
        this.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("ChefWalkRight");
            
       }
       else if(Input.GetKey("left")){
           this.GetComponent<SpriteRenderer>().flipX = true;
            anim.Play("ChefWalkRight");
           
       }
        else if(Input.GetKey("up")){
            anim.Play("ChefWalkDOwn");
           
       }
        else if(Input.GetKey("down")){
            anim.Play("ChefWalkUp");
            
       }
       else {
            anim.Play("Idle");
       }
      
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Lasagna"){
            SceneManager.LoadScene("LasagnaStartGame");
        }
        else if (other.tag == "Oven"){
          // SceneManager.LoadScene("LasagnaStartGame");
        }
        else if (other.tag == "Veggies"){
           // SceneManagement.LoadScene("LasagnaStartGame");
        }
    }
    
}

