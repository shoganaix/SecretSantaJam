using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private GameObject lifeBar;
    [SerializeField]
    private float maxLife = 10;
    [SerializeField]
    private float healPower = 2;
    public float damage = 1;
    private float life;
    private bool bubble = false;
    public bool isDamage = false;
    private float bubbleAux = 0;
    public float scaleBar = 2;

    void Awake()
    {
        life = maxLife;
        scaleBar = lifeBar.GetComponent<RectTransform>().localScale.x;
    }

    public float GetLife()
    {
        return life;
    }
    public void SetLife(float newLife)
    {
        life  = newLife;
    }

    public void GetDamage(float Damage)
    {
        if (!bubble)
        {
            lifeBar.GetComponent<SpriteRenderer>().color = Color.red;
            life -= Damage;
            StartCoroutine((changeBarColor()));
            isDamage = true;
        }
    }

    public void Heal()
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        life += healPower;
        if (life > maxLife)
            life = maxLife;
        StartCoroutine((changeBarColor()));
    }

    public void Heal(int heal)
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        life += heal;
        if (life > maxLife)
            life = maxLife;
        StartCoroutine((changeBarColor()));
    }

    public void ActivateBubble()
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.cyan;
        bubbleAux = 0;
        bubble = true;
        StartCoroutine((changeBarColor()));
    }

    void Update()
    {
        float fillAmount = life / maxLife;
        if (life <= 0)
            fillAmount = 0;
        lifeBar.GetComponent<RectTransform>().localScale = new Vector3(fillAmount * scaleBar, 0.25f, 1);
        if(bubble)
        {
            bubbleAux += Time.deltaTime;
            if(bubbleAux > 0.1)
            {
                bubble = false;
            }
        }
    }

    private IEnumerator changeBarColor()
    {
        yield return new WaitForSeconds(0.3f);
        lifeBar.GetComponent<SpriteRenderer>().color = Color.white;
        isDamage = false;
    }
}
