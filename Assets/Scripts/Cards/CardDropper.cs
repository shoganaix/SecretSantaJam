using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDropper : MonoBehaviour
{
    public Card card;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CardDropper")
        {
            card.isTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CardDropper")
            card.isTrigger = false;
    }
}
