using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress Instance;

    public int unlockedLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int level)
    {
        if (level > unlockedLevel)
        {
            unlockedLevel = level;
        }
    }
}