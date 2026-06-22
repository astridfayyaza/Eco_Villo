using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public GameObject bingkai;
    public string characterName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        bingkai.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (CharacterSelect.selectedCharacter != characterName)
        {
            bingkai.SetActive(false);
        }
    }
}