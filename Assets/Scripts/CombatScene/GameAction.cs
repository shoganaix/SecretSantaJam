using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    up,
    down,
    left,
    rigth,
    damageLine,
    damageMelee,
    damageBasic,
    bubble,
    heal
}

public class GameAction : MonoBehaviour
{
    private int actionId = 0;

    public ActionType Type = ActionType.up;

    public void DoAction(Grid_Gameplay grid, int id)
    {
        switch (Type)
        {
            case ActionType.up:
                Move(grid ,- 1, id);
                break;
            case ActionType.down:
                Move(grid, 1, id);
                break;
            case ActionType.left:
                Move(grid, 3, id);
                break;
            case ActionType.rigth:
                Move(grid, -3, id);
                break;
            case ActionType.heal:
                Heal(grid, id);
                break;
            case ActionType.bubble:
                Bubble(grid, id);
                break;
            case ActionType.damageLine:
                damageLine(grid, id);
                break;
            case ActionType.damageMelee:
                damageMelee(grid, id);
                break;
            case ActionType.damageBasic:
                damageBasic(grid, id);
                break;
            default:
                Debug.Log("Action done, but bad Type");
                break;
        }
    }

    private void Move(Grid_Gameplay grid, int dir, int id)
    {
        if(id == -1)
            grid.Move(dir);
        else
            grid.Move(dir, id);
    }

    public void Heal(Grid_Gameplay grid, int id)
    {
        actionId = id;
        Timer.heal += AuxHeal;
    }
    public void AuxHeal(Grid_Gameplay grid)
    {
        if (actionId == -1 && grid.GetObjectIndex(grid.GetObjectbyIndex(actionId)) >= 0 
            && grid.GetObjectIndex(grid.GetObjectbyIndex(actionId)) <= 2)
        {
            grid.player.GetComponent<CharacterStats>().Heal();
        }
        else if (grid.GetObjectIndex(grid.GetObjectbyIndex(actionId)) >= 9
            && grid.GetObjectIndex(grid.GetObjectbyIndex(actionId)) <= 11)
        {
            grid.GetObjectbyIndex(actionId).GetComponent<CharacterStats>().Heal();
        }
        Timer.heal -= AuxHeal;
    }
    public void Bubble(Grid_Gameplay grid, int id)
    {
        actionId = id;
        Timer.heal += AuxBubble;
    }

    public void AuxBubble(Grid_Gameplay grid)
    {
        if (actionId == -1)
            grid.player.GetComponent<CharacterStats>().ActivateBubble();
        else
            grid.GetObjectbyIndex(actionId).GetComponent<CharacterStats>().ActivateBubble();
        Timer.heal -= AuxBubble;
    }

    public void damageMelee(Grid_Gameplay grid, int id)
    {
        actionId = id;
        Timer.damage += AuxdamageMelee;
    }
    public void AuxdamageMelee(Grid_Gameplay grid)
    {
        grid.MeleeDamage(actionId);
        Timer.damage -= AuxdamageMelee;
    }

    public void damageLine(Grid_Gameplay grid, int id)
    {
        actionId = id;
        Timer.damage += AuxdamageLine;
    }
    public void AuxdamageLine(Grid_Gameplay grid)
    {
        grid.lineDamage(actionId);
        Timer.damage -= AuxdamageLine;
    }

    public void damageBasic(Grid_Gameplay grid, int id)
    {
        actionId = id;
        Timer.damage += AuxdamageBasic;
    }
    public void AuxdamageBasic(Grid_Gameplay grid)
    {
        grid.basicDamage(actionId);
        Timer.damage -= AuxdamageBasic;
    }
}