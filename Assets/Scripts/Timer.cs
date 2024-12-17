using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    public Grid grid;
    public static event Action<Grid> Event;
    public static event Action stealCard;
    public static event Action enemy;
    [SerializeField]
    private RectTransform timerBar;
    [SerializeField]
    private float timer = 0;
    private float timerAux = 0;


    private void Update()
    {
        timerAux += Time.deltaTime;
        if (timerBar != null)
        {
            float fillAmount = 1f - (timerAux / timer);
            timerBar.localScale = new Vector3(Mathf.Clamp01(fillAmount)*20, 1.5f, 1);
        }
        if(timerAux >= timer)
        {
            if (Event != null)
                Event.Invoke(grid);
            if (stealCard != null)
                stealCard.Invoke();
            if (enemy != null)
                enemy.Invoke();
            timerAux = 0;
        }
    }

}
