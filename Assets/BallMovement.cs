using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text AIScore;

    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
        Invoke("StartBall", 2f);   
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1,0) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        hitCounter = 0;
        Invoke("StartBall", 2f); //chama a função StartBall depois de 2 segundos
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDir, yDir;

        if(transform.position.x > 0)
        {
            xDir = -1;
        }
        else
        {
            xDir = 1;
        }

        yDir = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDir == 0)
        {
            yDir = 0.25f;
        }
        rb.velocity = new Vector2(xDir, yDir) * (initialSpeed + (speedIncrease * hitCounter));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}
