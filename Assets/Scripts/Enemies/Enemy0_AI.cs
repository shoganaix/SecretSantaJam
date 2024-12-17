using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy0_AI : MonoBehaviour
{
    public int initPos = 10;
    public ActionType[] secuence;

    void Start()
    {
        Timer.enemy += ExecutePattern;
    }

    void Update()
    {
    }

    void ExecutePattern()
    {

    }
    /*
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
    }*/
}
