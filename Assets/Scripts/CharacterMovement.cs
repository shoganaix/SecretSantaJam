using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //private Grid map;
    //private int currentpos = 1; // Pos actual
    /*
    void Start()
    {
        Timer.enemy += MoveToGridObject;
        map = FindObjectOfType<Grid>();
        if (map == null)
            Debug.LogError("No se encontro");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentpos - 1 >= 0 && currentpos - 1 != 2)
            {
                Debug.Log("W pressed");
                currentpos--;
                //MoveToGridObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentpos + 3 < 6)
            {
                Debug.Log("A pressed");
                currentpos += 3;
                //MoveToGridObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentpos + 1 < 6 && currentpos + 1 != 3)
            {
                currentpos++;
                Debug.Log("S pressed");
                //MoveToGridObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentpos - 3 >= 0)//out of limits (more than 2)
            {
                currentpos -= 3;
                Debug.Log("D pressed");
                //MoveToGridObject();
            }
        }
    }

    void MoveToGridObject()
    {
        var targetPosition = map.GetPosition(currentpos);

        if (targetPosition)
        {
            transform.position = targetPosition.transform.position;
            Debug.Log($"Character New pos: {currentpos}");
        }
        else
            Debug.LogWarning("No se pudo mover");
    }*/
}
