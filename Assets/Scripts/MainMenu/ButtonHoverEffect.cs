using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public GameObject selectionGroup;

    private Color defaultColor = new Color(163f / 255f, 163f / 255f, 163f / 255f);
    private Color hoverColor = Color.white;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor;
        }

        if (selectionGroup != null)
        {
            selectionGroup.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = defaultColor;
        }

        if (selectionGroup != null)
        {
            selectionGroup.SetActive(false);
        }
    }
}
