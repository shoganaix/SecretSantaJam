using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public Sprite sprite;
    [HideInInspector]
    public CardContainer cardContainer;
    [HideInInspector]
    public Vector3 originPos;
    [HideInInspector]
    public Vector3 originScale;
    [HideInInspector]
    public Quaternion originRot;
    private bool isBack = false;
    [HideInInspector]
    public bool isDragging = false;
    [HideInInspector]
    public bool isTrigger = false;
    private bool isOn = false;
    private float animSpeed = 100f;

    private Vector3 targetScale;
    [HideInInspector]
    public Vector3 targetPosition;
    [HideInInspector]
    public Quaternion targetRotation;

    void Start()
    {
        originScale = transform.localScale;
        targetScale = originScale;
        targetPosition = originPos;
        targetRotation = originRot;
    }

    public void CardAction(Grid grid)
    {
        Debug.Log("Action");
        Timer.Event -= CardAction;
    }

    void OnMouseDrag()
    {
        isDragging = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        if (isDragging && isTrigger)
        {
            PlayedCard();
        }
        else if(isDragging)
        {
            isOn = false;
            cardContainer.ResetCardsPositions();
        }
        isDragging = false;
        isBack = true;
    }

    void PlayedCard()
    {
        Timer.Event += CardAction;
        cardContainer.RemoveCard(this);

        targetScale = originScale;
        targetPosition = originPos;
        targetRotation = originRot;
        transform.position = originPos;
        transform.localScale = originScale;
        transform.rotation = originRot;
        isBack = false;
        isOn = false;
        cardContainer.ResetCardsPositions();
    }

    void OnMouseOver()
    {
        if (!isBack && !isDragging && !isOn && !cardContainer.isUpdatingCards)
        {
            targetScale = originScale * 1.2f;
            targetPosition = originPos + Vector3.up * 0.3f + Vector3.forward * -0.1f;
            targetRotation = Quaternion.identity;
            cardContainer.AdjustCardsForHover(gameObject, 0.3f);
            isOn = true;
        }
        if(cardContainer)
            isOn = false;
    }

    void OnMouseExit()
    {
        if (!isBack && !isDragging && !cardContainer.isUpdatingCards)
        {
            targetScale = originScale;
            targetPosition = originPos;
            targetRotation = originRot;
            cardContainer.ResetCardsPositions();
            isOn = false;
        }
        if(cardContainer)
            targetScale = originScale;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CardDropper")
            isTrigger = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CardDropper")
            isTrigger = false;
    }

    void Update()
    {
        if (isBack)
        {
            targetPosition = originPos;
            targetScale = originScale;
            targetRotation = originRot;
        }
        if(!isDragging && !cardContainer.isUpdatingCards)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animSpeed);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * animSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * animSpeed);
        }

        if (isBack && Vector3.Distance(transform.position, originPos) < 0.05f)
        {
            transform.position = originPos;
            isBack = false;
            if(isOn)
                cardContainer.ResetCardsPositions();
            isOn = false;
            transform.localScale = originScale;
            transform.rotation = originRot;
        }
    }
}
