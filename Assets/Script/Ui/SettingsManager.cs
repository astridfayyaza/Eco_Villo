using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject resolutionPanel;

    public TMP_Text resolutionText;

    private string selectedMode;

    void Start()
    {
        selectedMode = PlayerPrefs.GetString(
            "ScreenMode",
            "Same As Gameplay"
        );

        resolutionText.text = selectedMode;

        resolutionPanel.SetActive(false);
    }

    public void ToggleResolutionPanel()
    {
        resolutionPanel.SetActive(
            !resolutionPanel.activeSelf
        );
    }

    public void SelectWindowed()
    {
        selectedMode = "Windowed";
        resolutionText.text = selectedMode;

        resolutionPanel.SetActive(false);
    }

    public void SelectSameAsGameplay()
    {
        selectedMode = "Same As Gameplay";
        resolutionText.text = selectedMode;

        resolutionPanel.SetActive(false);
    }

    public void SelectFullscreen()
    {
        selectedMode = "Fullscreen";
        resolutionText.text = selectedMode;

        resolutionPanel.SetActive(false);
    }

    public void ApplySettings()
    {
        PlayerPrefs.SetString(
            "ScreenMode",
            selectedMode
        );

        PlayerPrefs.Save();

        if (selectedMode == "Windowed")
        {
            Screen.fullScreen = false;
        }

        else if (selectedMode == "Fullscreen")
        {
            Screen.fullScreen = true;
        }

        Debug.Log("Settings Applied");
    }

    public void ResetSettings()
    {
        selectedMode = "Same As Gameplay";

        resolutionText.text = selectedMode;

        PlayerPrefs.SetString(
            "ScreenMode",
            selectedMode
        );

        PlayerPrefs.Save();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}