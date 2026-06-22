using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}