using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;

    [Header("Menu Playlist")]
    public AudioClip[] menuPlaylist;

    [Header("Gameplay Music")]
    public AudioClip level1Music;
    public AudioClip level2Music;

    private int currentTrack = 0;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        ChangeMusic(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        // Playlist hanya berjalan di menu
        if (!isPaused &&
            IsMenuScene(SceneManager.GetActiveScene().name) &&
            !audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusic(scene.name);
    }

    bool IsMenuScene(string scene)
    {
        return scene == "MainMenu"
            || scene == "CharacterSelect"
            || scene == "LoadGame"
            || scene == "Settings";
    }

    void ChangeMusic(string sceneName)
    {
        if (IsMenuScene(sceneName))
        {
            if (menuPlaylist.Length == 0)
                return;

            audioSource.loop = false;

            if (audioSource.clip != menuPlaylist[currentTrack])
            {
                audioSource.Stop();
                audioSource.clip = menuPlaylist[currentTrack];
                audioSource.Play();
            }

            return;
        }

        AudioClip gameplayClip = null;

        switch (sceneName)
        {
            case "Level1":
                gameplayClip = level1Music;
                break;

            case "Level2":
                gameplayClip = level2Music;
                break;
        }

        if (gameplayClip != null)
        {
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.clip = gameplayClip;
            audioSource.Play();
        }
    }

    void NextTrack()
    {
        currentTrack++;

        if (currentTrack >= menuPlaylist.Length)
            currentTrack = 0;

        audioSource.clip = menuPlaylist[currentTrack];
        audioSource.Play();
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

    public void SetMenuVolume(float volume)
    {
        if (IsMenuScene(SceneManager.GetActiveScene().name))
        {
            audioSource.volume = volume;
        }
    }

    public void SetGameplayVolume(float volume)
    {
        if (!IsMenuScene(SceneManager.GetActiveScene().name))
        {
            audioSource.volume = volume;
        }
    }
}