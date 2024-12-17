using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    movement,
    damage,
    bubble,
    heal
}

public abstract class GameAction
{
    public abstract void DoAction(GameObject target);
}

public class AttackAction : GameAction
{
    public int Damage = 10;

    public override void DoAction(GameObject target)
    {
        // Implementa el daño al objetivo
        var health = target.GetComponent<CharacterStats>();
        if (health != null)
        {
            health.GetDamage(Damage);
        }
    }
}

public class HealAction : GameAction
{
    public int HealAmount = 15;

    public override void DoAction(GameObject target)
    {
        // Implementa la curación al objetivo
        var health = target.GetComponent<CharacterStats>();
        if (health != null)
        {
            health.Heal(HealAmount);
        }
    }
}

public class BubbleAction : GameAction
{
    public float Duration = 5f;

    public override void DoAction(GameObject target)
    {
        // Implementa la burbuja protectora
        var shield = target.GetComponent<CharacterStats>();
        if (shield != null)
        {
            shield.ActivateBubble();
        }
    }
}

public class MovementAction : GameAction
{
    public float Duration = 5f;

    public override void DoAction(GameObject target)
    {
        // Implementa la burbuja protectora
        var shield = target.GetComponent<CharacterStats>();
        if (shield != null)
        {
            shield.ActivateBubble();
        }
    }
}