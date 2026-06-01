using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public string itemName;

    public int price = 20;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                PlayerMoney money =
                    collision.GetComponent<PlayerMoney>();

                if (money != null)
                {
                    bool success =
                        money.SpendCoins(price);

                    if (success)
                    {
                        PlayerTools tools =
                            collision.GetComponent<PlayerTools>();

                        if (tools != null)
                        {
                            tools.hasVacuum = true;
                        }

                        Debug.Log("Vacuum berhasil dibeli");
                    }
                }
            }
        }
    }
}