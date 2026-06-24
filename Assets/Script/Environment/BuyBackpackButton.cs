using UnityEngine;

public class BuyBackpackButton : MonoBehaviour
{
    public int price = 150;

    public int extraSlots = 5;

    public PlayerMoney money;

    public PlayerInventory inventory;

    private bool purchased = false;

    public void Buy()
    {
        if (purchased)
            return;

        if (money.SpendCoins(price))
        {
            inventory.maxCapacity += extraSlots;

            purchased = true;

            Debug.Log(
                "Backpack berhasil diupgrade"
            );
        }
    }
}