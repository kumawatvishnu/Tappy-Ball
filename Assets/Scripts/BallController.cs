using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody2D rb;
    public float upForce;
    bool started;
    bool gameOver;
    public float rotationFactor;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
            }
        }
        else if(started && !gameOver)  
        {
            transform.Rotate(0, 0, rotationFactor);
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0, 0);

                rb.AddForce(new Vector2(0, upForce));
            }
        }
        if (gameOver == true)
        {
            transform.Rotate(0, 0, 0);
            rb.velocity = new Vector2(0, -4);
            //GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("ball");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            GameManager.instance.GameOver();
            GetComponent<Animator>().Play("ball");
        }
        if(collision.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManger.instance.IncrementScore();
        }
    }
}
