using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    // Vectors
    [SerializeField] Vector3 gravity;
    // Variables Float
    [SerializeField] float movX, gravityModifier;
    public LayerMask Ground;
    float speed = 5.0f;
    public float rayCastlong = 0.5f;

    // Variables Int
    public float jumpForce = 5.0f;
    // Booleans

    private bool isOnGrounded;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        // Component called
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        // Fisicas physics
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {

        // Orientacion de la animacion
        playerAnimator.SetFloat("Speed", Mathf.Abs(movX) * speed);


        // Movimiento jugador
        MovePlayer();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastlong, Ground);
        isOnGrounded = hit.collider != null;
        if (Input.GetButtonDown("Jump") && isOnGrounded )
        {
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        // Change of position 
        if (movX < 0)
        {
            transform.localScale = new Vector3(-5, 5, 0);
        }
        if (movX > 0)
        {
            transform.localScale = new Vector3(5, 5, 0);
        }
    }
    // Movimiento
    void MovePlayer()
    {
        movX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * movX);
    }
    // Colisiones
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = true;
        }

    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayCastlong);
    }

}
