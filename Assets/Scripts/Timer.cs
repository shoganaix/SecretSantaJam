using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    public CharacterStats[] characters;
    public static event Action<CharacterStats[]> Event;
    [SerializeField]
    private float timer = 0;
    private float timerAux = 0;

private void Update()
{
    timerAux += Time.deltaTime;
    if(timerAux >= timer)
    {
        if (Event != null)
            Event.Invoke(characters);
        timerAux = 0;
    }
}

}
