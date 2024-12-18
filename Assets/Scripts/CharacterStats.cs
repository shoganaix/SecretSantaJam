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
    private float bubbleAux = 0;

    void Awake()
    {
        life = maxLife;
    }

    public void GetDamage(float Damage)
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.red;
        if (!bubble)
            life -= Damage;
        StartCoroutine((changeBarColor()));
    }

    public void Heal()
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        life += healPower;
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
        lifeBar.GetComponent<RectTransform>().localScale = new Vector3(fillAmount * 2, 0.25f, 1);
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
        yield return new WaitForSeconds(0.25f);
        lifeBar.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
