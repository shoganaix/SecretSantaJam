using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int mapPos;
    public Card_SO[] deckBasic;
    //[HideInInspector]
    public Card_SO[] deck;
    [HideInInspector]
    public float PlayerLife = 10;
    public float PlayerMaxLife = 10;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCardToDeck(Card_SO newCard)
    {
        Card_SO[] newDeck = new Card_SO[deck.Length + 1];

        for (int i = 0; i < deck.Length; i++)
        {
            newDeck[i] = deck[i];
        }
        newDeck[deck.Length] = newCard;
        deck = newDeck;
    }

    public void LoadMap()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Level_1":
                GameController.Instance.mapPos = 1;
                SceneManager.LoadScene("Map");
                break;

            case "Level_2":
                GameController.Instance.mapPos = 2;
                SceneManager.LoadScene("Map");
                break;

            case "Level3_1":
                GameController.Instance.mapPos = 3;
                SceneManager.LoadScene("Map");
                break;

            case "Level3_2":
                GameController.Instance.mapPos = 4;
                SceneManager.LoadScene("Map");
                break;

            case "Level4_1":
                GameController.Instance.mapPos = 5;
                SceneManager.LoadScene("Map");
                break;

            case "Level4_2":
                GameController.Instance.mapPos = 6;
                SceneManager.LoadScene("Map");
                break;

            case "Level5_1v":
                GameController.Instance.mapPos = 7;
                SceneManager.LoadScene("Map");
                break;

            case "Level5_2":
                GameController.Instance.mapPos = 8;
                SceneManager.LoadScene("Map");
                break;

            case "Level5_3":
                GameController.Instance.mapPos = 9;
                SceneManager.LoadScene("Map");
                break;

            case "Level6_1":
                GameController.Instance.mapPos = 10;
                SceneManager.LoadScene("Map");
                break;

            case "Level6_2":
                GameController.Instance.mapPos = 11;
                SceneManager.LoadScene("Map");
                break;

            case "Level6_3":
                GameController.Instance.mapPos = 12;
                SceneManager.LoadScene("Level6_3.2");
                break;

            case "Level_Boss":
                GameController.Instance.mapPos = 13;
                SceneManager.LoadScene("Map");
                break;

            default:
                Debug.LogWarning("Not a Scene");
                break;
        }
        Debug.Log($"New pos: {GameController.Instance.mapPos}");
    }

    public void ResetGame()
    {
        deck = (Card_SO[])deckBasic.Clone();
        PlayerMaxLife = 10;
        PlayerLife = PlayerMaxLife;
        GameController.Instance.mapPos = 0;

    }
}
