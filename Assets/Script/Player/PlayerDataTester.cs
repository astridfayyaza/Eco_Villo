using UnityEngine;

public class PlayerDataTester : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Nama Player : " + CharacterSelect.playerName);
        Debug.Log("Character : " + CharacterSelect.selectedCharacter);
    }
}