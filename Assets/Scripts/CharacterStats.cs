using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private RectTransform lifeBar;
    [SerializeField]
    private float maxLife = 10;
    [SerializeField]
    private float healPower = 2;
    public float damage = 1;
    private float life;
    private bool bubble = false;
    private float bubbleAux = 0;

    void Awake()
    {
        life = maxLife;
    }

    public void GetDamage(float Damage)
    {
        if(!bubble)
            life -= Damage;
    }

    public void Heal()
    {
        life += healPower;
        if(life > maxLife)
            life = maxLife;
    }

    public void ActivateBubble()
    {
        bubbleAux = 0;
        bubble = true;
    }

    void Update()
    {
        if (lifeBar != null)
        {
            float fillAmount = life / maxLife;
            Debug.Log(fillAmount);
            lifeBar.localScale = new Vector3(fillAmount * 2, 0.25f, 1);
        }
        if(bubble)
        {
            bubbleAux += Time.deltaTime;
            if(bubbleAux > 0.1)
                bubble = false;
        }
    }
}
