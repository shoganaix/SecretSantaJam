using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int mapPos;
    public Card_SO[] deck;
    [HideInInspector]
    public float PlayerLife = -1;
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

            case "LevelBoss":
                GameController.Instance.mapPos = 13;
                SceneManager.LoadScene("Map");
                break;

            default:
                Debug.LogWarning("Not a Scene");
                break;
        }
        Debug.Log($"New pos: {GameController.Instance.mapPos}");
    }
}
