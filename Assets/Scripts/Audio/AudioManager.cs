using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource menuAudioSource;
    public AudioSource gameAudioSource;

    public AudioClip menuClip;
    public AudioClip gameClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        gameAudioSource.Stop();
        menuAudioSource.clip = menuClip;
        menuAudioSource.Play();
    }

    public void PlayGameMusic()
    {
        menuAudioSource.Stop();
        gameAudioSource.clip = gameClip;
        gameAudioSource.Play();
    }
}

