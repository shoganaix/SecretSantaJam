using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    public Grid_Gameplay grid;
    public static event Action<Grid_Gameplay> Event;
    public static event Action<Grid_Gameplay> heal;
    public static event Action<Grid_Gameplay> damage;
    public static event Action stealCard;
    [SerializeField]
    private RectTransform timerBar;
    [SerializeField]
    private float timer = 0;
    private float timerAux = 0;

    private bool stopTimer = false;

    private void Start()
    {
        PlayerGamePlay.PlayerDead += StopTime;
    }

    private void Update()
    {
        if (!stopTimer)
            timerAux += Time.deltaTime;
        if (timerBar != null)
        {
            float fillAmount = 1f - (timerAux / timer);
            timerBar.localScale = new Vector3(Mathf.Clamp01(fillAmount)* 10, 10, 10);
        }
        if(timerAux >= timer)
        {
            if (Event != null)
                Event.Invoke(grid);
            if (stealCard != null)
                stealCard.Invoke();
            if (heal != null)
                heal.Invoke(grid);
            if (damage != null)
                damage.Invoke(grid);
            timerAux = 0;
        }
    }

    public void StopTime()
    {
        stopTimer = true;
    }
}
