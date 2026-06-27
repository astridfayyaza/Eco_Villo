using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public GameObject bingkaiJohny;

    public TMP_InputField nameInput;

    public static string selectedCharacter;
    public static string playerName;

    void Start()
    {
        bingkaiJohny.SetActive(true);

        selectedCharacter = "Johny";
        playerName = "";
    }

    public void PilihJohny()
    {
        selectedCharacter = "Johny";

        bingkaiJohny.SetActive(true);
  
    }


    public void StartJourney()
    {
        playerName = nameInput.text.Trim();

        if (selectedCharacter == "")
        {
            Debug.Log("Pilih karakter dulu!");
            return;
        }

        if (playerName == "")
        {
            Debug.Log("Masukkan nama dulu!");
            return;
        }


        if (SaveSlotManager.selectedSlot == 1)
        {
            PlayerPrefs.SetString("SaveSlot1_Name", playerName);
            PlayerPrefs.SetString("SaveSlot1_Character", selectedCharacter);
            PlayerPrefs.SetString("SaveSlot1_Date",
                System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        }


        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }
}