using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemName;

    public int amount = 1;

    public int coinValue = 1;

    public ToolType requiredTool = ToolType.None;
}