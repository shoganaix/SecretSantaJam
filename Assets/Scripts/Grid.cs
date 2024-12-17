using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private GameObject[] GridObects = new GameObject[12];

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GridObects[i] = transform.GetChild(i).gameObject;
        }

        Debug.Log("Posiciones cargadas correctamente.");
    }

    public GameObject GetPosition(int index)
    {
        if (index >= 0 && index < GridObects.Length)
        {
            return GridObects[index];
        }

        Debug.LogWarning("Index fuera de rango");
        return null;
    }

    void Update()
    {
        
    }
}


