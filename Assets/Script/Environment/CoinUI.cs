using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public PlayerMoney money;

    public TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text =
            "Coins: " + money.coins;
    }
}