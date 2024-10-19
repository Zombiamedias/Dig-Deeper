using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource musicSource, fxSource;
    private void Awake() 
    {
        // Singleton Pattern para tener una única instancia de AudioManager
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Método para reproducir efectos de sonido a partir de un AudioSource
    public void PlaySFX(AudioSource source)
    {
        if(source != null)
        {
            source.Play(); // Reproduce el AudioSource que contiene el sonido FX
        }
    }
    // Método para reproducir música a partir de un AudioSource
    public void PlayMusic(AudioSource source)
    {
        if(source != null)
        {
            musicSource.Stop(); // Detén la música actual
            musicSource.clip = source.clip; // Asigna el clip del nuevo AudioSource
            musicSource.Play(); // Reproduce la nueva música
            musicSource.loop = true; // Establece la música para que se reproduzca en bucle
        }
    }
}