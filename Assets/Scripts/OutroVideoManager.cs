using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class OutroVideoManager : MonoBehaviour
{
    public VideoPlayer outroVideoPlayer;  // Asigna el VideoPlayer desde el Inspector

    void Start()
    {
        // Asegúrate de que el video comience desde el principio
        outroVideoPlayer.time = 0;
        
        // Llama a la función para reproducir el video
        outroVideoPlayer.Play();
        
        // Llama a EndReached cuando el video termina
        outroVideoPlayer.loopPointReached += EndReached;  
    }

    void EndReached(VideoPlayer vp)
    {
        // Regresar a la escena del menú cuando el video termina
        SceneManager.LoadScene("Menu");
    }
}