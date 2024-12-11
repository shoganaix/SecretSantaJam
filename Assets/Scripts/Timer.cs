using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    public CharacterStats[] characters;
    public static event Action<CharacterStats[]> Event;
    public static event Action stealCard;
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
            if (stealCard != null)
                stealCard.Invoke();
            timerAux = 0;
        }
    }

}
