using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    public TMP_Text slotText;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");

            slotText.text =
                playerName +
                "\nLast Played";
        }
        else
        {
            slotText.text =
                "Empty Slot\nCreate New Game";
        }
    }
}