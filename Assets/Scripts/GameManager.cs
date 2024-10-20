using UnityEngine;
public class GameManager : MonoBehaviour
{
    public AudioListener gameAudioListener; // Asigna el AudioListener de la cámara en la escena del juego

    void Start()
    {
        // Asegúrate de que el AudioListener del juego está activado al iniciar
        if (gameAudioListener != null)
        {
            gameAudioListener.enabled = true; // Activa el AudioListener del juego
        }
    }
}