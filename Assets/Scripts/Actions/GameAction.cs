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

public class GameAction : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private int heal = 15;
    private int id = 0;

    public ActionType Type = ActionType.up;

    public void DoAction(Grid grid)
    {
        switch (Type)
        {
            case ActionType.up:
                grid.Move(-1);
                break;
            case ActionType.down:
                grid.Move(1);
                break;
            case ActionType.left:
                grid.Move(3);
                break;
            case ActionType.rigth:
                grid.Move(-3);
                break;
            case ActionType.damageLine:
                break;
            case ActionType.damageMelee:
                break;
            case ActionType.damageRange:
                break;
            case ActionType.bubble:
                break;
            case ActionType.heal:
                break;
            default:
                Debug.Log("Action done, but bad id");
                break;
        }
    }

    public void DoAction(Grid grid, int id)
    {
        switch (Type)
        {
            case ActionType.up:
                Debug.Log(" up ");
                grid.Move(-1, id);
                break;
            case ActionType.down:
                Debug.Log(" down ");
                grid.Move(1, id);
                break;
            case ActionType.left:
                Debug.Log(" left ");
                grid.Move(3, id);
                break;
            case ActionType.rigth:
                Debug.Log(" rigth ");
                grid.Move(-3, id);
                break;
            case ActionType.heal:
                Heal(grid, id);
                break;
            case ActionType.bubble:
                break;
            case ActionType.damageLine:
                break;
            case ActionType.damageMelee:
                break;
            case ActionType.damageRange:
                break;
            default:
                Debug.Log("Action done, but bad id");
                break;
        }
    }

    public void Heal(Grid grid, int id)
    {

        Timer.heal += Heal;
    }
    public void Heal(Grid grid)
    {

    }
}