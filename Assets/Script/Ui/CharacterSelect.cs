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

        SceneManager.LoadScene("Eco_Villo");
    }
}