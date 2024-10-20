using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsManager : MonoBehaviour
{
    public AudioListener introAudioListener; // Asignar el AudioListener de IntroVideoScene en el Inspector
    public AudioListener gameAudioListener;  // Asignar el AudioListener de GameScene en el Inspector
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de cambio de escena
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Desuscribirse del evento al destruir el objeto
    }

    // Este método se llamará cada vez que una nueva escena se cargue
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroVideoScene")
        {
            // Activar el AudioListener de la escena de video y desactivar el del juego
            introAudioListener.enabled = true;
            gameAudioListener.enabled = false;
        }
        else if (scene.name == "GameScene")
        {
            // Activar el AudioListener de la escena de juego y desactivar el del video
            introAudioListener.enabled = false;
            gameAudioListener.enabled = true;
        }
    }
}