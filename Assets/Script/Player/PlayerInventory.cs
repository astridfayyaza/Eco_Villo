using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Dictionary<string, int> items = new Dictionary<string, int>();

    public int maxCapacity = 5;

    public int currentAmount = 0;

    public bool AddItem(string itemName, int amount)
    {
        if (currentAmount + amount > maxCapacity)
        {
            Debug.Log("Inventory penuh!");
            return false;
        }

        if (items.ContainsKey(itemName))
        {
            items[itemName] += amount;
        }
        else
        {
            items.Add(itemName, amount);
        }

        currentAmount += amount;

        Debug.Log(itemName + " = " + items[itemName]);

        return true;
    }

    public void ClearInventory()
    {
        items.Clear();

        currentAmount = 0;

        Debug.Log("Inventory dikosongkan");
    }
}
