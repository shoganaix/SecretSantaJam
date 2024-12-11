using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : Card
{
    public int heal = 5;

    public override void CardAction(CharacterStats charact)
    {
        charact.Heal(heal);
    }
}
