using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    melee,
    distance,
    line
}

public class DamageCard : Card
{
    public int damage = 4;
    public DamageType damageType;

    public override void CardAction(CharacterStats charact)
    {
        charact.GetDamage(damage);
    }
}
