using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDropper : MonoBehaviour
{
    
    void Start()
    {
        Timer.Event += Printf;
    }

    private void Printf()
    {
        Debug.Log("Works");
        Timer.Event -= Printf;
    }
}
