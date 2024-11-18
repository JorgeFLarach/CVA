using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;


public class playerController : MonoBehaviour
{
    public bool fstMove = true;
    public InputAction playerControls;
    public float speed = 4f;
    // Start is called before the first frame update
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
       // PlayerPrefs.SetFloat("Timer", 70);
      //  timer = PlayerPrefs.GetFloat("Timer", 70);
       // PlayerPrefs.Save();

       // DontDestroyOnLoad(gameObject); 
    }

    public void Update(){

      //  timeText.text = timer.ToString("F2");
      timer = PlayerPrefs.GetFloat("Timer");
        if (timer > 0){
            moveDir = playerControls.ReadValue<Vector2>();
        }

     //   if (timer < 0){
         // show panel quickly then go to battle ground
      //  }

   
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

