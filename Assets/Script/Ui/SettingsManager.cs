using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Resolution")]
    public GameObject resolutionPanel;
    public TMP_Text resolutionText;

    private string selectedMode;

    [Header("Audio")]
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        //RESOLUTION 

        selectedMode = PlayerPrefs.GetString(
            "ScreenMode",
            "Same As Gameplay"
        );

        resolutionText.text = selectedMode;

        resolutionPanel.SetActive(false);

        //AUDIO

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        void ApplyAudio()
        {
            PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

            SetMixerVolume("MasterVolume", masterSlider.value);

            // Slider Music hanya mengatur musik gameplay
            SetMixerVolume("GameMusicVolume", musicSlider.value);

            // Slider SFX mengatur efek suara UI/game
            SetMixerVolume("SFXVolume", sfxSlider.value);
        }
    }


    // RESOLUTION
    public void ToggleResolutionPanel()
    {
        resolutionPanel.SetActive(!resolutionPanel.activeSelf);
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

 
    // APPLY
    public void ApplySettings()
    {
        // RESOLUTION

        PlayerPrefs.SetString(
            "ScreenMode",
            selectedMode
        );

        if (selectedMode == "Windowed")
        {
            Screen.fullScreen = false;
        }
        else if (selectedMode == "Fullscreen")
        {
            Screen.fullScreen = true;
        }

        // AUDIO 

        ApplyAudio();

        PlayerPrefs.Save();

        Debug.Log("Settings Applied");
    }

    //
    // AUDIO
    //

    void ApplyAudio()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

        SetMixerVolume("MasterVolume", masterSlider.value);
        SetMixerVolume("MusicVolume", musicSlider.value);
        SetMixerVolume("SFXVolume", sfxSlider.value);
    }

    void SetMixerVolume(string parameter, float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat(parameter, Mathf.Log10(value) * 20);
    }

    //
    // RESET
    //

    public void ResetSettings()
    {
        // RESOLUTION//

        selectedMode = "Same As Gameplay";
        resolutionText.text = selectedMode;

        PlayerPrefs.SetString(
            "ScreenMode",
            selectedMode
        );

        // AUDIO

        masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;

        ApplyAudio();

        PlayerPrefs.Save();
    }

    //

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}