using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite sprite;

    virtual public void CardAction(CharacterStats charact){}
}

public class HealCard : Card
{
    public int heal = 5;

    public override void CardAction(CharacterStats charact)
    {
        charact.Heal(heal);
    }
}

public class BubbleCard : Card
{

    public override void CardAction(CharacterStats charact)
    {

    }
}

public enum DamageType
{
    damege,
    heal,
    shield
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