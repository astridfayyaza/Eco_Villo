using UnityEngine;

public class ToolController : MonoBehaviour
{
    public float vacuumRange = 2f;

    public float sweepRange = 1f;

    public LayerMask trashLayer;

    public KeyCode useToolKey = KeyCode.Space;

    public InventoryMessage inventoryMessage;

    private PlayerTools playerTools;

    private PlayerInventory inventory;


    void Start()
    {
        playerTools =
            GetComponent<PlayerTools>();

        inventory =
            GetComponent<PlayerInventory>();
    }


    void Update()
    {
        if (Input.GetKeyDown(useToolKey))
        {
            UseTool();
        }
    }


    void UseTool()
    {
        switch (playerTools.currentTool)
        {
            case ToolType.Vacuum:
                UseVacuum();
                break;

            case ToolType.Sweep:
                UseBroom();
                break;
        }
    }


    void UseVacuum()
    {
        CollectTrash(vacuumRange);
    }


    void UseBroom()
    {
        CollectTrash(sweepRange);
    }


    void CollectTrash(float range)
    {
        Collider2D[] trashObjects =
            Physics2D.OverlapCircleAll(
                transform.position,
                range,
                trashLayer
            );


        foreach (Collider2D trash in trashObjects)
        {
            Collectable item =
                trash.GetComponent<Collectable>();


            if (item != null)
            {
                bool success = inventory.AddItem(item.itemName, item.amount, item.coinValue);

                if (success)
                {
                    Destroy(trash.gameObject);
                }
                else
                {
                    inventoryMessage.ShowMessage(
                        "Inventory Sudah Penuh!"
                    );
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(
            transform.position,
            sweepRange
        );


        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(
            transform.position,
            vacuumRange
        );
    }
}