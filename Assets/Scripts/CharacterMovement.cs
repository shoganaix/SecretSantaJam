using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject pos_00;
    public GameObject pos_01;
    public GameObject pos_02;
    public GameObject pos_10;
    public GameObject pos_11;
    public GameObject pos_12;

    private GameObject[,] gridObjects; // Matriz
    private int currentX = 1, currentY = 0; // Pos actual

    void Start()
    {
        // Creo la cuadricula
        gridObjects = new GameObject[2, 3] 
        {
            { pos_00, pos_01, pos_02 },
            { pos_10, pos_11, pos_12 },
        };

        // Coloco al jugador en 0-0
        if (gridObjects[currentY, currentX] != null)
        {
            transform.position = gridObjects[currentY, currentX].transform.position;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentY - 1 >= 0)//out of limits (more than 2)
            {
                currentY--;
                Debug.Log("S pressed");
                MoveToGridObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentX - 1 >= 0) //out of limits (less than 0)
            {
                Debug.Log("A pressed");
                currentX--;
                MoveToGridObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentY + 1 < gridObjects.GetLength(0))
            {
                Debug.Log("W pressed");
                currentY++;
                MoveToGridObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentX + 1 < gridObjects.GetLength(1))
            {
                currentX++;
                Debug.Log("D pressed");
                MoveToGridObject();
            }
        }
    }

    void MoveToGridObject()
    {
        if (gridObjects[currentY, currentX] != null)
        {
            transform.position = gridObjects[currentY, currentX].transform.position;
            Debug.Log($"New pos: ({currentX}, {currentY})");
        }
        else
        {
            Debug.Log("No se puede mover");
        }
    }
}
