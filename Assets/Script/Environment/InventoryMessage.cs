using TMPro;
using UnityEngine;
using System.Collections;

public class InventoryMessage : MonoBehaviour
{
    public TextMeshProUGUI warningText;

    public void ShowMessage(string message)
    {
        StopAllCoroutines();

        StartCoroutine(
            ShowRoutine(message)
        );
    }

    IEnumerator ShowRoutine(string message)
    {
        warningText.text = message;

        yield return new WaitForSeconds(2f);

        warningText.text = "";
    }
}