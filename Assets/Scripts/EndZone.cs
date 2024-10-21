using UnityEngine;
using UnityEngine.SceneManagement;
public class EndZone : MonoBehaviour
{
    public string outroScene = "OutroVideoScene"; // Asigna el nombre de la escena del video de salida

    // Este método se llama cuando otro collider entra en este trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo ha entrado en el trigger: " + other.gameObject.name);

        // Comprueba si el collider que entra es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha colisionado con el trigger. Cargando escena: " + outroScene);
            SceneManager.LoadScene(outroScene);
        }
        else
        {
            Debug.Log("No es el jugador quien ha colisionado.");
        }
    }
}