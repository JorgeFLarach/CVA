using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    //public Sprite[] sprites;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public float speed = 0.5f;
    public float lifeTime = 30f;
    public float lives = 10;
    public bool reloading = false;
    public bool pancaked = false;
    public float reloadtime = 3f;
    public float loadprog = 0f;
    public GameObject shotPrefab;

    public GameObject audioSource;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if (reloading == false){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pancakes")){
            pancaked = true;
            GameData.playerScore += 250;
            speed = 0;
            spriteRenderer.color = new Color(0.6f, 0.4f, 0.2f, 1f); // Brown color

        }
        if (collision.gameObject.CompareTag("Food"))
        {
            lives--;
            if (lives <= 0)
            {
                GameData.playerScore += 250;
                GameData.shooters.Remove(this);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("GameEnd"))
        {
            GameOver();
        }
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void GameOver()
    {
        rb.velocity = Vector2.zero;
        if(GameData.playerScore > GameData.highScore){
            GameData.highScore = GameData.playerScore;
        }
        SceneManager.LoadScene("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(reloading == false && pancaked == false){
            if (other.gameObject.CompareTag("Food")){
                Instantiate(shotPrefab, gameObject.transform.position, gameObject.transform.rotation);
                audioSource = GameObject.FindGameObjectWithTag("AudioManagerLaser");
                audioSource.GetComponent<AudioManager2>().playLaser = true;
                reloading = true;
                //Kerpow!
                // Debug.Log("Reloading Start");
                StartCoroutine(ReloadingTime());

            }
        }
    }

    IEnumerator ReloadingTime() {
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(reloadtime);
        // Debug.Log("Reloading Done");
        // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        reloading = false;
    }
    public void TurnBlue()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public void TurnRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void TurnWhite()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
