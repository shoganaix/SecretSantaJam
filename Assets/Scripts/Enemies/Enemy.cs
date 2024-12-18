using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int initPos = 0;
    [SerializeField]
    private CharacterStats Stats;
    [SerializeField]
    private ActionType[] secuence;
    [SerializeField]
    private GameAction gameAction;

    [HideInInspector]
    public int id;

    private int count = 0;

    private void Awake()
    {
        if (gameAction == null)
        {
            gameAction = GetComponent<GameAction>();
            if (gameAction == null)
                gameAction = gameObject.AddComponent<GameAction>();
        }
    }

    void Start()
    {
        Timer.Event += ExecutePattern;
    }

    void ExecutePattern(Grid grid)
    {
        if (count >= secuence.Length)
            count = 0;
        gameAction.Type = secuence[count];
        gameAction.DoAction(grid, id);
        count++;
    }
}
