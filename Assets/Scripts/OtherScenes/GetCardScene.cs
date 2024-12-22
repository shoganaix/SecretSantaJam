using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetCardScene : MonoBehaviour
{
    public GameObject imageFade;
    public GameObject[] buttons;
    private Card_SO[] cards = new Card_SO[3];

    void Start()
    {
        SetCards();
        StartCoroutine(initCoroutine());
    }

    private void SetCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = GameController.Instance.deck[Random.Range(0, GameController.Instance.deck.Length)];
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = cards[i].sprite;
        }
    }

    private IEnumerator initCoroutine()
    {
        float elapsedTime = 0f;
        SpriteRenderer image = imageFade.GetComponent<SpriteRenderer>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / 1.5f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void ButtonPressed()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (clickedButton != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] == clickedButton)
                    GameController.Instance.AddCardToDeck(cards[i]);
                else
                    buttons[i].GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            StartCoroutine(LastCoroutine());
        }
    }


    private IEnumerator LastCoroutine()
    {
        float elapsedTime = 0f;
        SpriteRenderer image = imageFade.GetComponent<SpriteRenderer>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1.5f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        GameController.Instance.LoadMap();
    }
}
