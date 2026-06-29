using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    public TextMeshProUGUI percentText;

    [HideInInspector]
    public int totalTrash;

    private int collectedTrash;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public LevelManager levelManager;

    void Start()
    {
        UpdateUI();
    }

    public void RegisterTrash()
    {
        totalTrash++;
        UpdateUI();
    }

    public void TrashCollected()
    {
        collectedTrash++;

        if (collectedTrash > totalTrash)
            collectedTrash = totalTrash;

        UpdateUI();

        if (collectedTrash >= totalTrash)
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