using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreen;
    public float leftScreen;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        if(transform.position.x < leftScreen)
        {
            transform.position = new Vector2(leftScreen, transform.position.y);
        }
        if (transform.position.x > rightScreen)
        {
            transform.position = new Vector2(rightScreen, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("extraLife"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
    }
}
