using UnityEngine;

public class BackpackUpgrade : MonoBehaviour
{
    public int price = 150;

    public int extraSlots = 5;

    public void BuyUpgrade(
        PlayerMoney money,
        PlayerInventory inventory
    )
    {
        if(money.SpendCoins(price))
        {
            inventory.maxCapacity += extraSlots;

            Debug.Log(
                "Inventory menjadi " +
                inventory.maxCapacity
            );
        }
    }
}