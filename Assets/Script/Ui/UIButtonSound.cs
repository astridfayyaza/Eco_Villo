using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlaySound()
    {
        UIAudioManager.Instance.PlayButtonSound();
    }
}