using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<int> RemoveEnemy;
    public int initPos = 0;
    [SerializeField]
    private CharacterStats Stats;
    [SerializeField]
    private ActionType[] secuence;
    [SerializeField]
    private GameAction gameAction;

    [HideInInspector]
    public int id;

    private int count = 0;

    private float moveDownSpeed = 1f;
    private float fadeDuration = 1f;

    private void Awake()
    {
        if (gameAction == null)
        {
            gameAction = GetComponent<GameAction>();
            if (gameAction == null)
                gameAction = gameObject.AddComponent<GameAction>();
        }
    }

    void Start()
    {
        Timer.Event += ExecutePattern;
    }

    private void Update()
    {
        if (Stats.GetLife() <= 0)
            StartCoroutine((dead()));
    }

    void ExecutePattern(Grid grid)
    {
        if (count >= secuence.Length)
            count = 0;
        gameAction.Type = secuence[count];
        gameAction.DoAction(grid, id);
        count++;
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
        Timer.Event -= ExecutePattern;
        RemoveEnemy.Invoke(id);
        Destroy(gameObject);
    }
}
