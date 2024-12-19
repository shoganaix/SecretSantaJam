using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverSprite;
    public Button buttonComponent;

    void Start()
    {
        if (hoverSprite != null)
        {
            hoverSprite.SetActive(false);
        }
        if (buttonComponent == null)
        {
            buttonComponent = GetComponent<Button>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSprite != null && buttonComponent != null 
            && buttonComponent.interactable 
            && buttonComponent.gameObject.activeInHierarchy)
        {
            hoverSprite.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverSprite != null)
        {
            hoverSprite.SetActive(false);
        }
    }
}
