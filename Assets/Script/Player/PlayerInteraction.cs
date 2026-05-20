using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Collectable currentItem;

    private PlayerInventory inventory;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem != null)
            {
                bool success = inventory.AddItem(
                    currentItem.itemName,
                    currentItem.amount
                );

                if (success)
                {
                    Destroy(currentItem.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectable item = collision.GetComponent<Collectable>();

        if (item != null)
        {
            currentItem = item;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Collectable item = collision.GetComponent<Collectable>();

        if (item != null && item == currentItem)
        {
            currentItem = null;
        }
    }
}
