using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{

    public GameObject pausePanel;
    public VolumeSettings volumeSettings;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    IEnumerator StartGameRoutine()
    {
        UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSeconds(0.15f);

        SceneManager.LoadScene("CharacterSelect");
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSeconds(0.15f);

        SceneManager.LoadScene("LoadGame");
    }

    public void PauseGame()
    {
        Debug.Log("Pause ditekan!");

        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);

            Time.timeScale = 0f;

            if (MusicManager.Instance != null)
                MusicManager.Instance.PauseMusic();
        }
        else
        {
            if (volumeSettings != null)
                volumeSettings.CancelChanges();

            pausePanel.SetActive(false);

            Time.timeScale = 1f;

            if (MusicManager.Instance != null)
                MusicManager.Instance.ResumeMusic();
        }
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuRoutine());
    }

    IEnumerator MainMenuRoutine()
    {
        if (UIAudioManager.Instance != null)
            UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSecondsRealtime(0.15f);

        if (volumeSettings != null)
            volumeSettings.CancelChanges();

        Time.timeScale = 1f;

        if (MusicManager.Instance != null)
        {
            Destroy(MusicManager.Instance.gameObject);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        StartCoroutine(ExitRoutine());
    }

    IEnumerator ExitRoutine()
    {
        UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSeconds(0.15f);

        Application.Quit();
    }


    public void OpenSettings()
    {
        StartCoroutine(OpenSettingsRoutine());
    }

    IEnumerator OpenSettingsRoutine()
    {
        UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSeconds(0.15f);

        SceneManager.LoadScene("Settings");
    }
}