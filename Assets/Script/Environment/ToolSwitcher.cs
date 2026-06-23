using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    PlayerTools toolManager;


    void Start()
    {
        toolManager =
            GetComponent<PlayerTools>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Ganti alat");

            NextTool();
        }
    }


    void NextTool()
    {
        int index =
            toolManager.ownedTools.IndexOf(
                toolManager.currentTool
            );


        index++;


        if(index >= toolManager.ownedTools.Count)
        {
            index = 0;
        }


        toolManager.EquipTool(
            toolManager.ownedTools[index]
        );
    }
}