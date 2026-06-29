using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject winPanel;

    public int currentLevel = 1;

    void Start()
    {
        winPanel.SetActive(false);
    }

    public void CompleteLevel()
    {
        LevelProgress.Instance.UnlockLevel(
            currentLevel + 1
        );

        ShowWinPanel();
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        int currentScene =
            SceneManager.GetActiveScene().buildIndex;

        int nextScene =
            currentScene + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Semua level selesai");
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}