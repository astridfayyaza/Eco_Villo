using UnityEngine;

public class GameManager : MonoBehaviour
{
   public bool isGameActive;
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleScreen.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
    }
}
