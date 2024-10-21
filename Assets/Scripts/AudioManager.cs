using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Música de fondo")]
    public AudioSource backgroundMusic;
    public AudioClip[] backgroundMusicClips;

    [Header("Efectos de sonido")]
    public AudioSource soundEffectSource;
    public AudioClip[] soundEffectClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayRandomBackgroundMusic();
    }
    public void PlayRandomBackgroundMusic()
    {
        if (backgroundMusicClips.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundMusicClips.Length);
            backgroundMusic.clip = backgroundMusicClips[randomIndex];
            backgroundMusic.Play();
        }
    }
    public void PlayRandomSoundEffect()
    {
        if (soundEffectClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundEffectClips.Length);
            soundEffectSource.clip = soundEffectClips[randomIndex];
            soundEffectSource.Play();
        }
    }
}