using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyToolButton : MonoBehaviour
{
    public ToolType tool;

    public int price;

    public PlayerMoney money;

    public PlayerTools tools;


    public Button buyButton;

    public TextMeshProUGUI buttonText;


    void Update()
    {
        if(tools.ownedTools.Contains(tool))
        {
            buyButton.interactable = false;

            buttonText.text = "DIMILIKI";
        }
        else
        {
            buyButton.interactable = true;

            buttonText.text = "BELI";
        }
    }


    public void Buy()
    {
        if(money.SpendCoins(price))
        {
            tools.AddTool(tool);
        }
    }
}