using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;


    public void OnPointerEnter(PointerEventData eventData)
    {
        this.theText.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.theText.color = new Color(0.196f, 0.196f, 0.196f, 1);
    }
}