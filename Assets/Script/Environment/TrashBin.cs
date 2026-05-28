using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerInventory inventory =
                    collision.GetComponent<PlayerInventory>();

                PlayerMoney money =
                    collision.GetComponent<PlayerMoney>();

                if (inventory != null && money != null)
                {
                    int totalValue =
                        inventory.CalculateTotalValue();

                    if (totalValue > 0)
                    {
                        money.AddCoins(totalValue);

                        inventory.ClearInventory();

                        Debug.Log(
                            "Mendapat " +
                            totalValue +
                            " coins!"
                        );
                    }
                    else
                    {
                        Debug.Log(
                            "Inventory kosong"
                        );
                    }
                }
            }
        }
    }
}