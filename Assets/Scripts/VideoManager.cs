using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Asigna el VideoPlayer desde el Inspector
<<<<<<< Updated upstream
    public string nextScene = "SampleScene";  // Nombre de la siguiente escena

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;  // Cuando el video termina, llama a EndReached
=======
    public AudioListener audioListener; // Asigna el AudioListener de la escena IntroVideoScene
    public string nextScene = "Game";  // Nombre de la siguiente escena

    void Start()
    {
        // Asegúrate de que el video comienza desde 0
        videoPlayer.time = 0; // Asegúrate de que el tiempo inicial del VideoPlayer es 0
        videoPlayer.loopPointReached += EndReached;  // Llama a EndReached cuando el video termina

        // Comienza a reproducir el video
        videoPlayer.Play();
>>>>>>> Stashed changes
    }

    void EndReached(VideoPlayer vp)
    {
<<<<<<< Updated upstream
        SceneManager.LoadScene(nextScene);  // Carga la siguiente escena cuando el video termina
    }
}
=======
        // Desactivar el AudioListener de la escena del video antes de cambiar
        if (audioListener != null)
        {
            audioListener.enabled = false; // Desactiva el AudioListener
        }

        // Cargar la siguiente escena
        SceneManager.LoadScene(nextScene);
    }
}
>>>>>>> Stashed changes
