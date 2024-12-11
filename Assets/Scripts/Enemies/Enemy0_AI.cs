using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_AI : MonoBehaviour
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
        
    }
}
