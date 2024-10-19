using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovent : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D; // Se crea variable tipo Rigidbody para acceder a ese componente
    private float horizontal; // Se crea variable tipo float para guardar el movimiento lateral
    public float speed; // Se crea variable privada tipo float para modificar desde el inspector la velocidad de movimiento
    public float jumpForce; // Se crea variable tipo float para guardar la fuerza del salto se puede modificar en el inspector
    private bool grounded; // Se crea esta variable tipo booleana para saber si el jugador esta en el suelo  o no
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Se inicializa la variable tipo Rigidbody para acceder a ese componente
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // Movimiento laterales con flechas y letras del teclado "a" y "d"

        if (horizontal < 0.0f) // Se crea un condicional que dice que si estamos llendo hacia la izquierda gire hacia la derecha y viceversa en 
        {                       //caso que no se cumpla la condicion
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);// esto se codifico para que el salto no sobrepase el limite
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) // esto se codifico para que el salto no sobrepase el limite
        {
            grounded = true;
        }
        else
        {
            grounded= false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) // Se crea este condicional para que si se oprime la tecla espacio y grounded que es 
        {                                                // la que verifica que el  jugador esta en el suelo son verdaderas salta
            Jump();// llamamos el metodo de salto el cual se le aplica una fuerza
        }

    }

    private void Jump() // se crea metodo de salto
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);// Se modifica la velocidad del Rigidbody
    }
}
