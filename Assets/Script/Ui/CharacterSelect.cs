using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public GameObject bingkaiJohny;
    public GameObject bingkaiLuna;

    public TMP_InputField nameInput;

    public static string selectedCharacter;
    public static string playerName;

    void Start()
    {
        bingkaiJohny.SetActive(false);
        bingkaiLuna.SetActive(false);

        selectedCharacter = "";
        playerName = "";
    }

    public void PilihJohny()
    {
        selectedCharacter = "Johny";

        bingkaiJohny.SetActive(true);
        bingkaiLuna.SetActive(false);
    }

    public void PilihLuna()
    {
        selectedCharacter = "Luna";

        bingkaiLuna.SetActive(true);
        bingkaiJohny.SetActive(false);
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

        if (SaveSlotManager.selectedSlot == 2)
        {
            PlayerPrefs.SetString("SaveSlot2_Name", playerName);
            PlayerPrefs.SetString("SaveSlot2_Character", selectedCharacter);
            PlayerPrefs.SetString("SaveSlot2_Date",
                System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        }

        PlayerPrefs.Save();
        SceneManager.LoadScene("Eco_Villo");
    }
}