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
            case ToolType.None:
                CollectTrash(0.5f);
                break;

            case ToolType.Sweep:
                UseBroom();
                break;

            case ToolType.Vacuum:
                UseVacuum();
                break;
        }
    }

    bool CanCollect(ToolType playerTool, ToolType requiredTool)
    {
        return (int)playerTool >= (int)requiredTool;
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
            Collectable item = trash.GetComponent<Collectable>();

            if (item != null)
            {
                if (!CanCollect(
                    playerTools.currentTool,
                    item.requiredTool))
                {
                    inventoryMessage.ShowMessage(
                        "Membutuhkan " +
                        item.requiredTool
                    );

                    continue;
                }

                bool success =
                    inventory.AddItem(
                        item.itemName,
                        item.amount,
                        item.coinValue
                    );

                if (success)
                {
                    Debug.Log("Trash berhasil diambil");

                    TrashManager.Instance.TrashCollected();

                    Destroy(trash.gameObject);
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