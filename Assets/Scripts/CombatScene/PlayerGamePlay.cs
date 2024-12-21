using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamePlay : MonoBehaviour
{
    private Animator player_Anim;
    public static event Action PlayerDead;
    [SerializeField]
    private CharacterStats Stats;

    private float moveDownSpeed = 1f;
    private float fadeDuration = 1f;

    void Start()
    {
        if (GameController.Instance.PlayerLife == -1)
            GameController.Instance.PlayerLife = Stats.GetLife();
        else

            Stats.SetLife(GameController.Instance.PlayerLife);

        player_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Stats.GetLife() <= 0)
            StartCoroutine((dead()));
        player_Anim.SetBool("IsDamage", Stats.isDamage);
    }

    private IEnumerator dead()
    {
        float elapsedTime = 0f;
        Color originalColor = GetComponent<SpriteRenderer>().color;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < fadeDuration)
        {
            transform.position = new Vector3(
                originalPosition.x,
                originalPosition.y - (elapsedTime / fadeDuration) * moveDownSpeed,
                originalPosition.z
            );

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            GetComponent<SpriteRenderer>().color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                alpha
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GetComponent<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        transform.position = new Vector3(originalPosition.x, originalPosition.y - moveDownSpeed, originalPosition.z);

        yield return new WaitForSeconds(0.25f);
        PlayerDead.Invoke();
        Destroy(gameObject);
    }
}
