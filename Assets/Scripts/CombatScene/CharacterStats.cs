using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CharacterStats : MonoBehaviour
{
    private Animator charAnim;
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

        charAnim = GetComponent<Animator>();
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
            charAnim.SetBool("IsDamage", isDamage);
        }
    }

    public void Heal()
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        life += healPower;
        if (life > maxLife)
            life = maxLife;
        StartCoroutine((AnimateHeal()));
    }

    public void Heal(int heal)
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        life += heal;
        if (life > maxLife)
            life = maxLife;
        StartCoroutine((AnimateHeal()));
    }

    public void ActivateBubble()
    {
        lifeBar.GetComponent<SpriteRenderer>().color = Color.cyan;
        bubbleAux = 0;
        bubble = true;
        charAnim.SetBool("Bubble", bubble);
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
        charAnim.SetBool("Bubble", false);
        charAnim.SetBool("IsDamage", isDamage);
    }

    private IEnumerator AnimateHeal()
    {
        float elapsedTime = 0f;
        Debug.Log("entra");
        while (elapsedTime < 0.10f)
        {
            float color = Mathf.Lerp(255f, 100f, elapsedTime / 0.10f);
            float alphaX = Mathf.Lerp(3f, 2f, elapsedTime / 0.10f);
            float alphaY = Mathf.Lerp(3f, 3.5f, elapsedTime / 0.10f);
            transform.localScale = new Vector3(alphaX, alphaY, 0);
            transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < 0.20f)
        {
            float color = Mathf.Lerp(100f, 255, elapsedTime / 0.20f);
            float alphaX = Mathf.Lerp(2f, 3f, elapsedTime / 0.20f);
            float alphaY = Mathf.Lerp(3.5f, 3f, elapsedTime / 0.20f);
            transform.localScale = new Vector3(alphaX, alphaY, 0);
            transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(color, 255, color);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        lifeBar.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
