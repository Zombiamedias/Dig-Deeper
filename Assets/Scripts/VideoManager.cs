using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Asigna el VideoPlayer desde el Inspector
    public string nextScene = "SampleScene";  // Nombre de la siguiente escena

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;  // Cuando el video termina, llama a EndReached
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);  // Carga la siguiente escena cuando el video termina
    }
}