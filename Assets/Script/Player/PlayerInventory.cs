using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;

    public int amount;

    public int coinValue;
}

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItem> items =
        new List<InventoryItem>();

    public int maxCapacity = 5;

    public int currentAmount = 0;

    public bool AddItem(
        string itemName,
        int amount,
        int coinValue
    )
    {
        if (currentAmount + amount > maxCapacity)
        {
            Debug.Log("Inventory penuh!");

            return false;
        }

        InventoryItem existingItem =
            items.Find(item =>
                item.itemName == itemName
            );

        if (existingItem != null)
        {
            existingItem.amount += amount;
        }
        else
        {
            InventoryItem newItem =
                new InventoryItem();

            newItem.itemName = itemName;
            newItem.amount = amount;
            newItem.coinValue = coinValue;

            items.Add(newItem);
        }

        currentAmount += amount;

        Debug.Log(
            itemName + " x" + amount
        );

        return true;
    }

    public int CalculateTotalValue()
    {
        int total = 0;

        foreach (InventoryItem item in items)
        {
            total +=
                item.amount * item.coinValue;
        }

        return total;
    }

    public void ClearInventory()
    {
        items.Clear();

        currentAmount = 0;
    }

    public int GetTotalItems()
    {
        return currentAmount;
    }
}