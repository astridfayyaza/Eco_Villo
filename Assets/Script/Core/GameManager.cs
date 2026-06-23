using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;

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
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuRoutine());
    }

    IEnumerator MainMenuRoutine()
    {
        UIAudioManager.Instance.PlayButtonSound();

        yield return new WaitForSeconds(0.15f);

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