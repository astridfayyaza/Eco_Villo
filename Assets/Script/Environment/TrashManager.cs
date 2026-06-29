using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    public int totalTrash;

    public int cleanedTrash;

    public int cleanlinessPercent;

    public TextMeshProUGUI progressText;

    public LevelManager levelManager;

    private void Awake()
    {
        Instance = this;
    }


    public void RegisterTrash()
    {
        totalTrash++;

        UpdateUI();
    }


    public void CleanTrash()
    {
        cleanedTrash++;
        cleanlinessPercent = Mathf.Clamp(cleanlinessPercent + 1, 0, 100);

        UpdateUI();

        if (cleanlinessPercent >= 100)
        {
            levelManager.CompleteLevel();
        }
    }


    void UpdateUI()
    {
        progressText.text =
            "Kebersihan : " +
            cleanlinessPercent +
            "%";
    }
}