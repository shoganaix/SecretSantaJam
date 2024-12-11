using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : Card
{
    public int heal = 5;

    public override void CardAction(CharacterStats[] characters)
    {
        base.CardAction(characters);
        characters[0].Heal(heal);
    }
}
