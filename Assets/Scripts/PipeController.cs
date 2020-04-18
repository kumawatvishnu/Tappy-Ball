using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

    public float speed;
    public float UpDownSpeed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartMovePipe();

    }
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.gameOver == true)
        {
            StopPipe();
        }
		
	}
    public void StartMovePipe()
    {
        MovePipe();
        InvokeRepeating("SwitchUpDown", 0.1f, 1f);
    }
    void SwitchUpDown()
    {
        UpDownSpeed = -UpDownSpeed;
        rb.velocity = new Vector2(speed, UpDownSpeed);
    }
    void MovePipe()
    {
        rb.velocity = new Vector2(speed, UpDownSpeed);
    }
    void StopPipe()
    {
        CancelInvoke("SwitchUpDown");
        rb.velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }
}
