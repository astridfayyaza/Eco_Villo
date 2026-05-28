using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public TextMeshProUGUI inventoryText;

    void Update()
    {
        string text = "";

        foreach (var item in inventory.items)
        {
            text +=
                item.itemName +
                ": " +
                item.amount +
                "\n";
        }

        inventoryText.text = text;
    }
}