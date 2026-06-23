using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;

    public AudioClip[] playlist;

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
        PlayCurrentTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
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
}