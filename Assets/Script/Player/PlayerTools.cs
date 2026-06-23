using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public ToolType currentTool = ToolType.None;


    public List<ToolType> ownedTools =
        new List<ToolType>();


    void Start()
    {
        // awal game tidak memakai alat
        ownedTools.Add(ToolType.None);

        EquipTool(ToolType.None);
    }

    public void EquipTool(ToolType tool)
    {
        if(ownedTools.Contains(tool))
        {
            currentTool = tool;

            Debug.Log(
                "Tool aktif: " + currentTool
            );
        }
    }


    public void AddTool(ToolType tool)
    {
        if(!ownedTools.Contains(tool))
        {
            ownedTools.Add(tool);
        }
    }
}