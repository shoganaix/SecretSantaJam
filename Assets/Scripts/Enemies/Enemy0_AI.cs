using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_AI : MonoBehaviour
{
    private Map map;
    private int currentpos = 10; // Pos actual

    void Start()
    {
        Timer.enemy += MoveToGridObject;
        map = FindObjectOfType<Map>();
        if (map == null)
            Debug.LogError("No se encontro");
    }

    void Update()
    {
    }

    void MoveToGridObject()
    {
        currentpos = Random.Range(11, 6);
        var targetPosition = map.GetPosition(currentpos);

        if (targetPosition)
        {
            transform.position = targetPosition.transform.position;
            Debug.Log($"New pos: {currentpos}");
        }
        else
            Debug.LogWarning("No se pudo mover");
    }
}