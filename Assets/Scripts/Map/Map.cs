using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject[] Grid = new GameObject[12];

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Grid[i] = transform.GetChild(i).gameObject;
        }

        Debug.Log("Posiciones cargadas correctamente.");
    }

    public GameObject GetPosition(int index)
    {
        if (index >= 0 && index < Grid.Length)
        {
            return Grid[index];
        }

        Debug.LogWarning("Index fuera de rango");
        return null;
    }

    void Update()
    {
        
    }
}


