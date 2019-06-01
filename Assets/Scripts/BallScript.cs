using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool Play;
    public Transform paddle;
    public float speed;
    public Transform effect1;
    AudioSource audio1;
    public Transform powerup;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if(!Play)
        {
            //Moving of the paddle
            transform.position = paddle.position;
        }
        // Press the Spacebar to start the game
        if(Input.GetButtonDown ("Jump") && !Play)
        {
            Play = true;
            rb.AddForce (Vector2.up * speed);
        }
    }
    // When the ball collide with the bottom, the game will automatically restart and -1
    void OnTriggerEnter2D(Collider2D other)
    {
        // Condition when the player miss the ball
        if(other.CompareTag("bottom"))
        {
            Debug.Log("Ball hit the bottom of the screen");
            rb.velocity = Vector2.zero;
            Play = false;
            gm.UpdateLives(-1);
        }
    }
    // Effects of the collision when the ball collide with the bricks
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag ("brick"))
        {
            int randChance = Random.Range(1, 101);
            if(randChance < 50)
            {
                Instantiate(powerup, other.transform.position, other.transform.rotation);
            }
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if (brickScript.hittobreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {   
                // Effects
                Transform newExplosion = Instantiate(effect1, other.transform.position, other.transform.rotation);
                // Brick will be destroyed
                Destroy(newExplosion.gameObject, 2.5f);
                // tranfer the number of bricks that was destroyed into the point
                gm.UpdateScore(brickScript.point);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
        }
        // Play the music
        audio1.Play();
    }
}
