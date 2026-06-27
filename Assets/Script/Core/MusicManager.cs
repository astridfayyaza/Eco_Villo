using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;

    public AudioClip[] playlist;
    private bool isPaused = false;

    private int currentTrack = 0;

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
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        PlayCurrentTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && !isPaused)
        {
            NextTrack();
        }
    }

    void PlayCurrentTrack()
    {
        audioSource.clip = playlist[currentTrack];
        audioSource.Play();
    }

    void NextTrack()
    {
        currentTrack++;

        if (currentTrack >= playlist.Length)
        {
            currentTrack = 0;
        }

        PlayCurrentTrack();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PauseMusic()
    {
        isPaused = true;
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        isPaused = false;
        audioSource.UnPause();
    }
}