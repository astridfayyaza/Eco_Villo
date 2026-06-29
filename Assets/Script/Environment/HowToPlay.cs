using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        panel.SetActive(false);

        Time.timeScale = 1f;
    }
}