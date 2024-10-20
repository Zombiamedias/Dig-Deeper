using UnityEngine;
public class AudioManager : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======
    public static AudioManager instance;

    public AudioSource musicSource; // Background music
    public AudioSource sfxSource;   // Sound effects
    private AudioListener audioListener; // El AudioListener que está en el AudioManager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el AudioManager entre escenas
            audioListener = GetComponent<AudioListener>();
            audioListener.enabled = false; // Desactiva el AudioListener aquí
        }
        else
        {
            Destroy(gameObject); // Evita duplicación
        }
    }
    private void OnEnable()
    {
        
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
>>>>>>> Stashed changes
    }
}