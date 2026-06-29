using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    float savedMaster;
    float savedMusic;
    float savedSFX;

    void Start()
    {
        savedMaster = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        savedMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        savedSFX = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        masterSlider.value = savedMaster;
        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        masterSlider.onValueChanged.AddListener(PreviewMaster);
        musicSlider.onValueChanged.AddListener(PreviewMusic);
        sfxSlider.onValueChanged.AddListener(PreviewSFX);
    }

    void PreviewMaster(float value)
    {
        if (MusicManager.Instance != null)
            MusicManager.Instance.SetMenuVolume(value);
    }

    void PreviewMusic(float value)
    {
        if (MusicManager.Instance != null)
            MusicManager.Instance.SetGameplayVolume(value);
    }

    void PreviewSFX(float value)
    {
        if (UIAudioManager.Instance != null)
            UIAudioManager.Instance.SetSFXVolume(value);
    }

    public void Apply()
    {
        savedMaster = masterSlider.value;
        savedMusic = musicSlider.value;
        savedSFX = sfxSlider.value;

        PlayerPrefs.SetFloat("MasterVolume", savedMaster);
        PlayerPrefs.SetFloat("MusicVolume", savedMusic);
        PlayerPrefs.SetFloat("SFXVolume", savedSFX);

        PlayerPrefs.Save();
    }

    public void Cancel()
    {
        masterSlider.value = savedMaster;
        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        PreviewMaster(savedMaster);
        PreviewMusic(savedMusic);
        PreviewSFX(savedSFX);
    }
}