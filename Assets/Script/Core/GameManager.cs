using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        Debug.Log("Start ditekan!");
        SceneManager.LoadScene("Eco_Villo");
    }

    public void PauseGame()
    {
        Debug.Log("Pause ditekan!");
        
        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f; 
        } else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu ditekan!");
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Exit ditekan!");
        Application.Quit();
    }
}
