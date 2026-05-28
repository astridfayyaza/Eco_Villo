using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;

        Debug.Log("Coins: " + coins);
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;

            Debug.Log("Coins tersisa: " + coins);

            return true;
        }

        Debug.Log("Coin tidak cukup!");

        return false;
    }
}