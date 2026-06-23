using UnityEngine;

[System.Serializable]
public class ShopTool
{
    public string toolName;

    public ToolType toolType;

    public int price;
}


public class ShopManager : MonoBehaviour
{
    public ShopTool[] tools;


    private PlayerTools playerTools;
    private PlayerMoney playerMoney;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerTools =
                collision.GetComponent<PlayerTools>();

            playerMoney =
                collision.GetComponent<PlayerMoney>();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                BuyTool(0);
            }


            if(Input.GetKeyDown(KeyCode.N))
            {
                BuyTool(1);
            }
        }
    }


    void BuyTool(int index)
    {
        if(index >= tools.Length)
            return;


        ShopTool item = tools[index];


        if(playerMoney.SpendCoins(item.price))
        {
            playerTools.AddTool(
                item.toolType
            );


            Debug.Log(
                item.toolName + 
                " berhasil dibeli"
            );
        }
    }
}