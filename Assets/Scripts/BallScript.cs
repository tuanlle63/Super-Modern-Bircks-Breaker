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
            transform.position = paddle.position;
        }

        if(Input.GetButtonDown ("Jump") && !Play)
        {
            Play = true;
            rb.AddForce (Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bottom"))
        {
            Debug.Log("Ball hit the bottom of the screen");
            rb.velocity = Vector2.zero;
            Play = false;
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag ("brick"))
        {
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if (brickScript.hittobreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                Transform newExplosion = Instantiate(effect1, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);
                gm.UpdateScore(brickScript.point);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
        }
        audio1.Play();
    }
}
