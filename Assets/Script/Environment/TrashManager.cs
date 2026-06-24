using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    public int totalTrash;

    public int cleanedTrash;

    public TextMeshProUGUI progressText;


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

        UpdateUI();

        if (cleanedTrash >= totalTrash)
        {
            Debug.Log(
                "Area Bersih!"
            );
        }
    }


    void UpdateUI()
    {
        float percentage =
            ((float)cleanedTrash /
             totalTrash) * 100f;


        progressText.text =
            "Kebersihan : " +
            Mathf.RoundToInt(
                percentage
            ) +
            "%";
    }
}