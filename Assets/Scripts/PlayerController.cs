using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody controller;
    public Animator animator;
    // Vectors
    [SerializeField] Vector3 gravity;
    // Variables Float
    [SerializeField] float movX;
    float speed = 5.0f, speedRun = 20.0f, gravityScale= -9.8f;
    // Variables Int
    public int jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Orientacion de la animacion
        animator.SetFloat("Speed", Mathf.Abs(movX));

        MovePlayer();
      
    }
    void JumpPlayer(){
        gravity.y = Mathf.Sqrt(gravityScale * -2 *jumpForce);
        
    }
    void MovePlayer(){
        movX= Input.GetAxis("Horizontal")* speed;
        transform.Translate(Vector3.right * Time.deltaTime * movX );
        if (movX == -1)
        {
            
        }
    }
    void ApplyGravity()
    {
        gravity.y += gravityScale * Time.deltaTime;
        
    }
}
