using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    public TextMeshProUGUI percentText;

    [HideInInspector]
    public int totalTrash;

    private int collectedTrash;

    public LevelManager levelManager;

    private void Awake()
    {
        Debug.Log("TrashManager dibuat : " + gameObject.name);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RegisterTrash()
    {
        totalTrash++;

        Debug.Log("Register Trash : " + totalTrash);

        UpdateUI();
    }

    public void TrashCollected()
    {
        collectedTrash++;

        Debug.Log("Collected : " + collectedTrash + " / " + totalTrash);

        if (collectedTrash > totalTrash)
            collectedTrash = totalTrash;

        UpdateUI();

        if (totalTrash > 0 && collectedTrash >= totalTrash)
        {
            Debug.Log("Level Selesai!");

            levelManager.CompleteLevel();
        }
    }

    void UpdateUI()
    {
        if (percentText == null)
            return;

        if (totalTrash == 0)
        {
            percentText.text = "Kebersihan : 0%";
            return;
        }

        float percent =
            (float)collectedTrash /
            totalTrash * 100f;

        percentText.text =
            "Kebersihan : " +
            Mathf.RoundToInt(percent) +
            "%";
    }

    public void ResetLevel()
    {
        totalTrash = 0;
        collectedTrash = 0;

        UpdateUI();
    }
}