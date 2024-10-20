using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovent : MonoBehaviour

{
    public Rigidbody2D rigidbody2D;
    public float speed = 2f; // Velocidad de movimiento
    public float patrolDistance = 3f; // Distancia que recorre antes de cambiar de dirección
    private bool movingRight = true; // Para saber en qué dirección está el enemigo
    private Vector3 initialPosition; // Para almacenar la posición inicial del enemigo

    void Start()
    {
        initialPosition = transform.position; // Guardar la posición inicial del enemigo
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Movimiento de izquierda a derecha en un área determinada
        if (movingRight)
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            if (transform.position.x >= initialPosition.x + patrolDistance)
            {
                movingRight = false; // Cambiar dirección
                Flip();
            }
        }
        if (movingRight == false) 
        {
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
            rigidbody2D.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            if (transform.position.x <= initialPosition.x - patrolDistance)
            {
                movingRight = true; // Cambiar dirección
                Flip();
            }
        }
    }

    // Método para voltear el sprite del enemigo
    void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    // Si el player colisiona con el enemigo desde arriba, lo destruye
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificar si el player está cayendo sobre el enemigo
            if (collision.relativeVelocity.y <= 0 && collision.transform.position.y > transform.position.y)
            {
                Destroy(gameObject); // Destruir el enemigo
            }
            else
            {
                // Aquí podrías agregar lógica para dañar al jugador
            }
        }
    }
}