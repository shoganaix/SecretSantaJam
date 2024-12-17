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
    damageRange,
    bubble,
    heal
}

public class GameAction
{
    public int Damage = 10;
    public int Heal = 15;
    public ActionType Type = ActionType.up;

    void start()
    {

    }

    public void DoAction(Grid grid)
    {

    }
}