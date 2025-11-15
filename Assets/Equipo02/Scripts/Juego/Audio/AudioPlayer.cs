using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    private AudioSource musicSource;
    private AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip bg_theme;
    public AudioClip bg_last30;

    [Header("SFX Clips")]
    public AudioClip sfx_Correcto;
    public AudioClip sfx_Erroneo;
    public AudioClip sfx_SigRonda;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

            musicSource.loop = true;
            musicSource.volume = 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ----- MUSIC -----

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.loop = loop;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // ----- SFX -----

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
