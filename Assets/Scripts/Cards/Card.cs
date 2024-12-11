using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite sprite;
    [HideInInspector]
    public CardContainer cardContainer;
    private Vector3 originPos;
    private Vector3 originScale;
    private Quaternion originRot;
    private bool isBack = false;
    private bool isDragging = false;
    public bool isTrigger = false;
    private float backSpeed = 5f;

    virtual public void CardAction(CharacterStats[] characters) 
    {
        Debug.Log("Action");
        Timer.Event -= CardAction;
        Destroy(this);
    }

    protected void deleteCard()
    {
        cardContainer.RemoveCard(this);
        gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }
    
    void OnMouseDrag()
    {
        if (!isBack && originPos == Vector3.zero)
        {
            originPos = transform.position;
        }
        isDragging = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        if(isDragging == true && isTrigger == true)
        {
            PlayedCard();
        }
        isDragging = false;
        isBack = true;
    }

    void PlayedCard()
    {
        Timer.Event += CardAction;
        deleteCard();
    }

    void OnMouseEnter()
    {
        if (!isBack && !isDragging)
        {
            originScale = transform.localScale;
            originRot = transform.rotation;
            originPos = transform.position;
            transform.localScale = originScale * 1.2f;
            transform.position += Vector3.up * 0.3f;
            transform.position += Vector3.forward * -0.01f;
            transform.rotation = Quaternion.identity;
        }
    }

    void OnMouseExit()
    {
        if (!isBack && originPos != Vector3.zero && !isDragging)
        {
            transform.localScale = originScale;
            transform.position = originPos;
            transform.rotation = originRot;
        }
    }

    void Update()
    {
        if (isBack)
        {
            transform.position = Vector3.Lerp(transform.position, originPos, Time.deltaTime * backSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, originScale, Time.deltaTime * backSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, originRot, Time.deltaTime * backSpeed);

            if (Vector3.Distance(transform.position, originPos) < 0.05f)
            {
                transform.position = originPos;
                isBack = false;
                originPos = Vector3.zero;
                transform.localScale = originScale;
                transform.rotation = originRot;
            }
        }
    }
}
