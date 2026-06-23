using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI coinText;

    public PlayerMoney playerMoney;


    void Update()
    {
        coinText.text =
            "Coin : " +
            playerMoney.coins;
    }


    public void OpenShop()
    {
        panel.SetActive(true);
    }


    public void CloseShop()
    {
        panel.SetActive(false);
    }
}