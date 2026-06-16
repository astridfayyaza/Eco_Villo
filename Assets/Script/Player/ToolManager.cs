using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public ToolType currentTool = ToolType.None;


    public void EquipTool(ToolType tool)
    {
        currentTool = tool;

        Debug.Log(
            "Tool digunakan: " + currentTool
        );
    }


    public bool HasTool()
    {
        return currentTool != ToolType.None;
    }
}