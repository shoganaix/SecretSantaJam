using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public GameObject cardPrefab;
    public int maxCards = 5;
    public float offset = 1.7f;
    public Transform scaleChild;
    private GameObject[] cards;
    private Dictionary<GameObject, (Vector3 position, Quaternion rotation)> cardStates = new Dictionary<GameObject, (Vector3, Quaternion)>();
    private float animTime = 0.2f;


    void Start()
    {
        cards = new GameObject[maxCards];
        UpdateCardPositions();
        AddCard();
        AddCard();
        AddCard();
        AddCard();
        Timer.stealCard += AddCard;
    }

    public void AddCard()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == null)
            {
                GameObject newCard = Instantiate(cardPrefab, transform);
                cards[i] = newCard;
                cards[i].GetComponent<Card>().cardContainer = this;
                UpdateCardPositions();
                break;
            }
        }
    }

    public void RemoveCard(Card card)
    {
        for (int i = cards.Length - 1; i >= 0; i--)
        {
            if (cards[i] != null && cards[i].GetComponent<Card>() == card)
            {
                cards[i] = null;
                UpdateCardPositions();
                break;
            }
        }
    }

    private void UpdateCardPositions()
    {
        if (cards == null || scaleChild == null)
            return;

        Vector3 childScale = scaleChild.localScale;
        int activeCards = 0;

        foreach (var card in cards)
        {
            if (card != null)
                activeCards++;
        }
        if (activeCards == 0)
            return;

        float step = Mathf.Min(offset, childScale.x / activeCards);
        float startX = -((activeCards - 1) * step) / 2;
        float angleStep = activeCards > 1 ? -40f / (activeCards - 1) : 0;

        int index = 0;
        foreach (var card in cards)
        {
            if (card != null)
            {
                float xPosition = startX + index * step;
                float angle = activeCards > 1 ? 40f / 2 + index * angleStep : 0;
                float yOffset = 0;

                if (activeCards > 1)
                {
                    float normalizedPosition = (float)index / (activeCards - 1);
                    yOffset = transform.position.y * 0.5f * Mathf.Pow(normalizedPosition - 0.5f, 2) + 0.5f;
                }

                Vector3 targetPosition = new Vector3(xPosition, yOffset, 0);
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

                StartCoroutine(moveCards(card, targetPosition, targetRotation));

                index++;
            }
        }
    }

    private IEnumerator moveCards(GameObject card, Vector3 targetPos, Quaternion targetRot)
    {
        if (!cardStates.ContainsKey(card))
        {
            cardStates[card] = (card.transform.localPosition, card.transform.localRotation);
        }

        Vector3 initPos    = cardStates[card].position;
        Quaternion initRot = cardStates[card].rotation;
        float animTimeAux  = 0f;

        while (animTimeAux < animTime)
        {
            animTimeAux += Time.deltaTime;
            float t = animTimeAux / animTime;

            card.transform.localPosition = Vector3.Lerp(initPos, targetPos, t);
            card.transform.localRotation = Quaternion.Lerp(initRot, targetRot, t);

            yield return null;
        }

        card.transform.localPosition = targetPos;
        card.transform.localRotation = targetRot;
        cardStates[card] = (targetPos, targetRot);
    }
}