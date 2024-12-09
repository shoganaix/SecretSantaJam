using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    public static event Action Event;
    [SerializeField]
    private float timer = 0;
    private float timerAux = 0;

    private void Update()
    {
        timerAux += Time.deltaTime;
        if(timerAux >= timer)
        {
            Event.Invoke();
            timerAux = 0;
        }
    }
}
