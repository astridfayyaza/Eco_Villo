using TMPro;
using UnityEngine;

public class LoadSlotDisplay : MonoBehaviour
{
    public TMP_Text slot1Text;
    public TMP_Text slot2Text;

    void Start()
    {
        UpdateSlots();
    }

    void UpdateSlots()
    {
        if (PlayerPrefs.HasKey("SaveSlot1_Name"))
        {
            slot1Text.text =
                PlayerPrefs.GetString("SaveSlot1_Name") + "\n" +
                PlayerPrefs.GetString("SaveSlot1_Character") + "\n" +
                PlayerPrefs.GetString("SaveSlot1_Date");
        }
        else
        {
            slot1Text.text =
                "Empty Slot\nCreate New Game";
        }

        if (PlayerPrefs.HasKey("SaveSlot2_Name"))
        {
            slot2Text.text =
                PlayerPrefs.GetString("SaveSlot2_Name") + "\n" +
                PlayerPrefs.GetString("SaveSlot2_Character") + "\n" +
                PlayerPrefs.GetString("SaveSlot2_Date");
        }
        else
        {
            slot2Text.text =
                "Empty Slot\nCreate New Game";
        }
    }
}