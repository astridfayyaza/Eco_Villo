using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void StartGame()
    {
        Debug.Log("Start ditekan!");
        SceneManager.LoadScene("Eco_Villo");
    }

    public void ExitGame()
    {
        Debug.Log("Exit ditekan!");
        Application.Quit();
    }
}
