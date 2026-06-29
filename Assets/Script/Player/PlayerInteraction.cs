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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentItem != null)
            {
                bool success = inventory.AddItem(
                    currentItem.itemName,
                    currentItem.amount,
                    currentItem.coinValue
                );

                if (success)
                {
                    if (TrashManager.Instance != null)
                    {
                        TrashManager.Instance.CleanTrash();
                    }

                    Destroy(currentItem.gameObject);
                    currentItem = null;
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
