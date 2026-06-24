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

    public bool AddItem(string itemName, int amount, int coinValue)
    {
        int totalItems = 0;

        foreach (var item in items)
        {
            totalItems += item.amount;
        }

        if (totalItems >= maxCapacity)
        {
            Debug.Log("Inventory penuh!");
            return false;
        }

        InventoryItem existingItem =
            items.Find(i => i.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem
            {
                itemName = itemName,
                amount = amount,
                coinValue = coinValue
            });
        }

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