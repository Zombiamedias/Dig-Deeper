using UnityEngine;
public class EnemyMovent : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D; // Se crea variable tipo Rigidbody para acceder a ese componente
    private float horizontal; // Se crea variable tipo float para guardar el movimiento lateral
    public float speed; // Se crea variable privada tipo float para modificar desde el inspector la velocidad de movimiento
    public float jumpForce; // Se crea variable tipo float para guardar la fuerza del salto se puede modificar en el inspector
    private bool grounded; // Se crea esta variable tipo booleana para saber si el jugador está en el suelo o no
    // Nuevo array para los sonidos de salto
    public AudioClip[] jumpSounds; // Asigna tus clips de sonido en el inspector
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Se inicializa la variable tipo Rigidbody para acceder a ese componente
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // Movimiento laterales con flechas y letras del teclado "a" y "d"
        if (horizontal < 0.0f) // Si se va hacia la izquierda, girar
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red); // Ray para verificar si está en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) // Comprobar si está en el suelo
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) // Si se presiona espacio y está en el suelo
        {                                               
            Jump(); // Llama al método de salto
        }
    }
    private void Jump() // Método de salto
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce); // Aplicar fuerza hacia arriba
        
        // Reproducir sonido aleatorio
        if (jumpSounds.Length > 0) // Comprobar si hay sonidos en el array
        {
            // Elegir un sonido aleatorio del array
            AudioClip randomSound = jumpSounds[Random.Range(0, jumpSounds.Length)];
            AudioManager.instance.PlaySFX(randomSound); // Reproduce el sonido aleatorio
        }
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * speed, Rigidbody2D.velocity.y); // Se modifica la velocidad del Rigidbody
    }
}