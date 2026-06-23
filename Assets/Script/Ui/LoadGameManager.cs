using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameManager : MonoBehaviour
{
    public void OpenSlot1()
    {
        SaveSlotManager.selectedSlot = 1;

        if (PlayerPrefs.HasKey("SaveSlot1_Name"))
        {
            SceneManager.LoadScene("Eco_Villo");
        }
        else
        {
            SceneManager.LoadScene("CharacterSelect");
        }
    }

    public void OpenSlot2()
    {
        SaveSlotManager.selectedSlot = 2;

        if (PlayerPrefs.HasKey("SaveSlot2_Name"))
        {
            SceneManager.LoadScene("Eco_Villo");
        }
        else
        {
            SceneManager.LoadScene("CharacterSelect");
        }
    }
}