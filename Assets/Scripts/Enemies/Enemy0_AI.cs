using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_AI : MonoBehaviour
{
    private Map map;
    private int currentpos = 10; // Pos actual
    private bool rest = false;

    void Start()
    {
        Timer.enemy += ExecutePattern;
        map = FindObjectOfType<Map>();
        if (map == null)
            Debug.LogError("No se encontro");
    }

    void Update()
    {
    }

    void ExecutePattern()
    {
        if (rest)
        {
            currentpos = 10;
            MoveToPosition();
            rest = false;
        }
        else
        {
            currentpos -= 3;
            MoveToPosition();
            Attack();
            rest = true;
        }
    }

    void MoveToPosition()
    {
       // currentpos = Random.Range(11, 6);
        var targetPosition = map.GetPosition(currentpos);

        if (targetPosition)
        {
            transform.position = targetPosition.transform.position;
            Debug.Log($"Enemy New pos: {currentpos}");
        }
        else
            Debug.LogWarning("No se pudo mover");
    }

    void Attack()
    {
        Debug.Log("Atacando...");
    }
}
