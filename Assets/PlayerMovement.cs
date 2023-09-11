using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        //movimenta o jogador na vertical
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        //se y da bola for maior que y da AI, sobe a barra da AI
        //o 0.5f é pra ser mais natural
        if(ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0,1);
        }
        //se y da bola for menor que y da AI, desce a barra da AI
        else if(ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0,-1);    
        }
        else
        {
            //não faz nada, já que a bola está na direção da barra da AI
            playerMove = new Vector2(0,0);    
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }
}
