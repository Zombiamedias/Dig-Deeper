using UnityEngine;
using UnityEngine.SceneManagement;
public class EndZone : MonoBehaviour
{
    public string outroScene = "OutroVideoScene"; // Asigna el nombre de la escena del video de salida
    // Este método se llama cuando otro collider entra en este trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el collider que entra es el jugador
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene la etiqueta "Player"
        {
            // Cargar la escena del video de salida
            SceneManager.LoadScene(outroScene);
        }
    }
}