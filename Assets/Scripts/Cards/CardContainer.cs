using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public GameObject cardPrefab;
    public int maxCards = 5;
    public float offset = 1.7f;
    public Transform scaleChild;

    private List<GameObject> cardPool = new List<GameObject>();
    private List<GameObject> activeCards = new List<GameObject>();
    private List<GameObject> deck = new List<GameObject>(); // Mazo de cartas
    private Dictionary<GameObject, (Vector3 position, Quaternion rotation)> cardStates = new Dictionary<GameObject, (Vector3, Quaternion)>();
    private float animTime = 0.2f;
    [HideInInspector]
    public bool isUpdatingCards = false;

    void Start()
    {
        InitializePool();
        InitializeDeck();
        DealInitialCards();
        Timer.stealCard += DrawCard;
    }

    private void InitializePool()
    {
        for (int i = 0; i < maxCards * 2; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform);
            newCard.SetActive(false);
            cardPool.Add(newCard);
        }
    }

    private void InitializeDeck()
    {
        foreach (var card in cardPool)
        {
            if (!card.activeInHierarchy)
            {
                deck.Add(card);
            }
        }

        // Opcional: Barajar el mazo
        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        System.Random rng = new System.Random();
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = rng.Next(i, deck.Count);
            var temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    private void DealInitialCards()
    {
        for (int i = 0; i < maxCards; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (deck.Count == 0 || activeCards.Count >= maxCards)
            return;

        GameObject card = deck[0];
        deck.RemoveAt(0);

        card.SetActive(true);
        activeCards.Add(card);
        card.GetComponent<Card>().cardContainer = this;

        UpdateCardPositions();
    }

    public void RemoveCard(Card card)
    {
        if (activeCards.Contains(card.gameObject))
        {
            activeCards.Remove(card.gameObject);
            card.gameObject.SetActive(false);

            UpdateCardPositions();
        }
    }

    private GameObject GetCardFromPool()
    {
        foreach (var card in cardPool)
        {
            if (!card.activeInHierarchy)
            {
                card.SetActive(true);
                return card;
            }
        }
        return null;
    }

    public void AdjustCardsForHover(GameObject hoveredCard, float hoverOffset)
    {
        for (int i = 0; i < activeCards.Count; i++)
        {
            GameObject card = activeCards[i];
            if (card != hoveredCard)
            {
                Vector3 adjustedPosition = card.GetComponent<Card>().originPos;
                adjustedPosition.x += (i < activeCards.IndexOf(hoveredCard) ? -hoverOffset : hoverOffset);
                card.GetComponent<Card>().targetPosition = adjustedPosition;
            }
        }
    }

    public void ResetCardsPositions()
    {
        foreach (var card in activeCards)
        {
            card.GetComponent<Card>().targetPosition = card.GetComponent<Card>().originPos;
        }
    }

    private void UpdateCardPositions()
    {
        if (activeCards.Count == 0 || scaleChild == null)
            return;

        isUpdatingCards = true;
        Vector3 childScale = scaleChild.localScale;
        float step = Mathf.Min(offset, childScale.x / activeCards.Count);
        float startX = -((activeCards.Count - 1) * step) / 2;
        float angleStep = activeCards.Count > 1 ? -40f / (activeCards.Count - 1) : 0;
        float zOffsetStep = 0.02f;

        for (int i = 0; i < activeCards.Count; i++)
        {
            float xPosition = startX + i * step;
            float angle = activeCards.Count > 1 ? 40f / 2 + i * angleStep : 0;
            float yOffset = scaleChild.position.y;
            float zPosition = -i * zOffsetStep;

            if (activeCards.Count > 1)
            {
                float normalizedPosition = (float)i / (activeCards.Count - 1);
                yOffset += transform.position.y * 0.5f * Mathf.Pow(normalizedPosition - 0.5f, 2) + 0.5f;
            }

            Vector3 targetPosition = new Vector3(xPosition, yOffset, zPosition);
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            activeCards[i].GetComponent<Card>().originPos = targetPosition;
            activeCards[i].GetComponent<Card>().originRot = targetRotation;


            activeCards[i].GetComponent<Card>().targetPosition = targetPosition;
            activeCards[i].GetComponent<Card>().targetRotation = targetRotation;

            if (!activeCards[i].GetComponent<Card>().isDragging)
                StartCoroutine(moveCards(activeCards[i], targetPosition, targetRotation, i == activeCards.Count - 1));
        }
    }

    private IEnumerator moveCards(GameObject card, Vector3 targetPos, Quaternion targetRot, bool isLast)
    {
        if (!cardStates.ContainsKey(card))
            cardStates[card] = (card.transform.position, card.transform.localRotation);

        Vector3 initPos = cardStates[card].position;
        Quaternion initRot = cardStates[card].rotation;
        float animTimeAux = 0f;

        while (animTimeAux < animTime)
        {
            animTimeAux += Time.deltaTime;
            float t = animTimeAux / animTime;

            card.transform.position = Vector3.Lerp(initPos, targetPos, t);
            card.transform.localRotation = Quaternion.Lerp(initRot, targetRot, t);

            yield return null;
        }

        card.transform.position = targetPos;
        card.transform.localRotation = targetRot;

        cardStates[card] = (targetPos, targetRot);

        if (isLast)
            isUpdatingCards = false;
    }
}

