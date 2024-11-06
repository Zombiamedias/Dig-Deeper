using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource; // Background music
    public AudioSource sfxSource;   // Sound effects
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el AudioManager entre escenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicación
        }
    }
    // Métodos para manejar la música y los efectos de sonido
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}