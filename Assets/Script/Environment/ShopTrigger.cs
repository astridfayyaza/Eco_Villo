using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public ShopUI shopUI;


    private void OnTriggerEnter2D(
        Collider2D collision
    )
    {
        if(collision.CompareTag("Player"))
        {
            shopUI.OpenShop();
        }
    }


    private void OnTriggerExit2D(
        Collider2D collision
    )
    {
        if(collision.CompareTag("Player"))
        {
            shopUI.CloseShop();
        }
    }
}