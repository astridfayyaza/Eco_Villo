using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider musicSlider;

    float savedVolume;

    void Start()
    {
        savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        musicSlider.value = savedVolume;

        musicSlider.onValueChanged.AddListener(PreviewVolume);
    }

    public void ApplySettings()
    {
        savedVolume = musicSlider.value;

        PlayerPrefs.SetFloat("MusicVolume", savedVolume);
        PlayerPrefs.Save();

        if (MusicManager.Instance != null)
            MusicManager.Instance.SetVolume(savedVolume);
    }

    public void CloseSettings()
    {
        musicSlider.value = savedVolume;

        if (MusicManager.Instance != null)
            MusicManager.Instance.SetVolume(savedVolume);
    }

    void PreviewVolume(float value)
    {
        if (MusicManager.Instance != null)
            MusicManager.Instance.SetVolume(value);
    }

    public void CancelChanges()
    {
        savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        musicSlider.value = savedVolume;

        if (MusicManager.Instance != null)
            MusicManager.Instance.SetVolume(savedVolume);
    }
}