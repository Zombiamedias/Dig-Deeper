using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    Rigidbody2D playerRB;
    Animator playerAnimator;
    // Vectors
    // Variables Float
    [SerializeField] float movX, gravityModifier;
    public LayerMask Ground;
    public float speed = 3.0f;
    

    // Variables Int
    public float jumpForce = 5.0f;
    // Booleans

    private bool isOnGrounded = true;
    // bool hasPowerUp;
    // bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        // Component called
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        // Fisicas physics
        //Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {

        // Orientacion de la animacion
        playerAnimator.SetFloat("xSpeed", Mathf.Abs(playerRB.velocity.x));
        playerAnimator.SetFloat("ySpeed", playerRB.velocity.y);
        

        // movement player call
        MovePlayer();



        if (Input.GetButtonDown("Jump") && isOnGrounded)
        {
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //isOnGrounded= false;
            playerAnimator.SetBool("isJumping", !isOnGrounded);
        }

        // Run 
        
        // Change of position 
        if (movX < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 0);
        }
        if (movX > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
    }


    // Movimiento
    void MovePlayer()
    {
        movX = Input.GetAxis("Horizontal");
        playerRB.velocity= new Vector2 (movX * speed, playerRB.velocity.y);
        
    }


    // Colisiones
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = true;
            playerAnimator.SetBool("isJumping", !isOnGrounded);
        }
        }

      private void OnCollisionExit2D(Collision2D collision)
       {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = false;
            
        }
        
    }
    // Draw line vertical red for jump
}

