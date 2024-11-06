using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Asigna el VideoPlayer desde el Inspector
    public AudioListener audioListener; // Asigna el AudioListener de la escena IntroVideoScene
    public string nextScene = "Game";  // Nombre de la siguiente escena
    void Start()
    {
        // Asegúrate de que el video comienza desde 0
        videoPlayer.time = 0; // Asegúrate de que el tiempo inicial del VideoPlayer es 0
        videoPlayer.loopPointReached += EndReached;  // Llama a EndReached cuando el video termina

        // Comienza a reproducir el video
        videoPlayer.Play();
    }
    void EndReached(VideoPlayer vp)
    {
        // Desactivar el AudioListener de la escena del video antes de cambiar
        if (audioListener != null)
        {
            audioListener.enabled = false; // Desactiva el AudioListener
        }

        // Cargar la siguiente escena
        SceneManager.LoadScene(nextScene);
    }
}