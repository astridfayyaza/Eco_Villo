using UnityEngine;

public class VacuumController : MonoBehaviour
{
    public float vacuumRange = 2f;

    public LayerMask trashLayer;

    public KeyCode vacuumKey = KeyCode.Space;


    private PlayerTools toolManager;
    private PlayerInventory inventory;


    void Start()
    {
        toolManager = GetComponent<PlayerTools>();
        inventory = GetComponent<PlayerInventory>();
    }


    void Update()
    {
        if(toolManager.currentTool == ToolType.Vacuum)
        {
            if(Input.GetKey(vacuumKey))
            {
                Vacuum();
            }
        }
    }


    void Vacuum()
    {
        Collider2D[] trashObjects =
            Physics2D.OverlapCircleAll(
                transform.position,
                vacuumRange,
                trashLayer
            );


        foreach(Collider2D trash in trashObjects)
        {
            Collectable item =
                trash.GetComponent<Collectable>();


            if(item != null)
            {
                bool success =
                    inventory.AddItem(
                        item.itemName,
                        item.amount,
                        item.coinValue
                    );


                if(success)
                {
                    Destroy(trash.gameObject);
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
            transform.position,
            vacuumRange
        );
    }
}