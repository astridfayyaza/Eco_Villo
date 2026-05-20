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

                if (inventory != null)
                {
                    inventory.ClearInventory();

                    Debug.Log("Item dibuang!");
                }
            }
        }
    }
}