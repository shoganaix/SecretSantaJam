using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SceneManagement;

public class Grid_Gameplay : MonoBehaviour
{
    private Dictionary<int, GameObject> gridOccupants;
    private int gridSize;

    public int startIndex = 0;
    public GameObject playerPrefab;
    [SerializeField]
    public GameObject player;
    public GameObject[] enemies;

    void Start()
    {
        gridSize = transform.childCount;
        gridOccupants = new Dictionary<int, GameObject>();

        SpawnPlayer();
        SetEnemies();
    }

    private void SpawnPlayer()
    {
        Transform spawnPosition = transform.GetChild(startIndex);
        player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        gridOccupants[startIndex] = player;

        PlayerGamePlay.PlayerDead += DeadPlayer;
    }

    private void SetEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            int enemyGridIndex = gridSize / 2 + enemies[i].GetComponent<Enemy>().initPos;
            Transform spawnPosition = transform.GetChild(enemyGridIndex);

            enemies[i].transform.position = spawnPosition.position;
            enemies[i].GetComponent<Enemy>().id = i + 1;
            enemies[i].GetComponent<Enemy>().RemoveEnemy += RemoveEnemy;

            gridOccupants[enemyGridIndex] = enemies[i];
        }
    }


    public void Move(int direction)
    {
        int currentIndex = GetObjectIndex(player);

        if (currentIndex == 3 && direction == -1)
            return;
        if (currentIndex == 2 && direction == 1)
            return;
        int newIndex = currentIndex + direction;

        if (newIndex >= 0 && newIndex < gridSize / 2)
        {
            MoveObject(currentIndex, newIndex, player);
        }
        return;
    }

    public int GetObjectIndex(GameObject obj)
    {
        foreach (var entry in gridOccupants)
        {
            if (entry.Value == obj)
            {
                return entry.Key;
            }
        }

        return -1;
    }

    public GameObject GetObjectbyIndex(int id)
    {
        foreach (var entry in gridOccupants)
        {
            if (!entry.Value.CompareTag("Enemy") && id == -1)
                return entry.Value;
            else if (entry.Value.CompareTag("Enemy") && entry.Value.GetComponent<Enemy>().id == id)
            {
                return entry.Value;
            }
        }
        return null;
    }

    public void Move(int direction, int enemyId)
    {
        foreach (var entry in gridOccupants)
        {
            if (entry.Value.CompareTag("Enemy") && entry.Value.GetComponent<Enemy>().id == enemyId)
            {
                int currentIndex = entry.Key;
                if(entry.Key == 100)
                    currentIndex = entry.Value.GetComponent<Enemy>().initPos;
                if (currentIndex == 9 && direction == -1)
                    break;
                if (currentIndex == 8 && direction == 1)
                    break;
                int newIndex = currentIndex + direction;

                if (newIndex >= 6 && newIndex < gridSize)
                {
                    MoveObject(entry.Key, newIndex, entry.Value);
                }

                break;
            }
        }
    }

    private void MoveObject(int currentIndex, int newIndex, GameObject obj)
    {
        gridOccupants.Remove(currentIndex);
        if (gridOccupants.ContainsKey(newIndex))
        {
            GameObject existingObj = gridOccupants[newIndex];
            existingObj.GetComponent<Enemy>().initPos = newIndex;
            gridOccupants[100] = existingObj;
        }
        gridOccupants[newIndex] = obj;

        obj.transform.position = transform.GetChild(newIndex).position;
    }

    public void MeleeDamage(int id)
    {

        if (id == -1)
        {
            foreach (var entry in gridOccupants)
            {
                if (entry.Value.CompareTag("Enemy") && GetObjectIndex(entry.Value) >= 6 && GetObjectIndex(entry.Value) <= 8 && 
                    GetObjectIndex(player) >= 3 && GetObjectIndex(player) <= 5)
                {
                    entry.Value.GetComponent<CharacterStats>().GetDamage(player.GetComponent<CharacterStats>().damage);
                }
            }
        }
        else if (GetObjectIndex(player) >= 3 && GetObjectIndex(player) <= 5 && 
            GetObjectIndex(GetObjectbyIndex(id)) >= 6 && GetObjectIndex(GetObjectbyIndex(id)) <= 8)
        {
            player.GetComponent<CharacterStats>().GetDamage(GetObjectbyIndex(id).GetComponent<CharacterStats>().damage);
        }
    }

    public void lineDamage(int id)
    {

        if (id == -1)
        {
            foreach (var entry in gridOccupants)
            {
                if (entry.Value.CompareTag("Enemy") && (GetObjectIndex(entry.Value) == 3 + GetObjectIndex(player) || GetObjectIndex(entry.Value) == 6 + GetObjectIndex(player) )&&
                    GetObjectIndex(player) >= 3 && GetObjectIndex(player) <= 5)
                {
                    entry.Value.GetComponent<CharacterStats>().GetDamage(player.GetComponent<CharacterStats>().damage);
                }
            }
        }
        else if ((GetObjectIndex(player) == 0 + (GetObjectIndex(GetObjectbyIndex(id)) - 6) || GetObjectIndex(player) == 3 + (GetObjectIndex(GetObjectbyIndex(id)) - 6) )&&
            GetObjectIndex(GetObjectbyIndex(id)) >= 6 && GetObjectIndex(GetObjectbyIndex(id)) <= 8)
        {
            player.GetComponent<CharacterStats>().GetDamage(GetObjectbyIndex(id).GetComponent<CharacterStats>().damage);
        }
    }
    
    public void basicDamage(int id)
    {

        if (id == -1)
        {
            foreach (var entry in gridOccupants)
            {
                if (entry.Value.CompareTag("Enemy") && GetObjectIndex(entry.Value) == GetObjectIndex(player) + 6)
                {
                    entry.Value.GetComponent<CharacterStats>().GetDamage(player.GetComponent<CharacterStats>().damage);
                }
            }
        }
        else if (GetObjectIndex(player) == GetObjectIndex(GetObjectbyIndex(id)) - 6)
        {
            player.GetComponent<CharacterStats>().GetDamage(GetObjectbyIndex(id).GetComponent<CharacterStats>().damage);
        }
    }

    public bool LastEnemy()
    {
        foreach (var entry in gridOccupants)
        {
            if (entry.Value.CompareTag("Enemy"))
            {
                return false;
            }
        }
        return true;
    }

    public void RemoveEnemy(int enemyId)
    {
        foreach (var entry in gridOccupants)
        {
            if (entry.Value.CompareTag("Enemy") && entry.Value.GetComponent<Enemy>().id == enemyId)
            {
                gridOccupants.Remove(entry.Key);
                if (LastEnemy())
                    NoMoreEnemies();
                break;
            }
        }
    }

    public void NoMoreEnemies()
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
            SceneManager.LoadScene("Map");
            break;

        case "LevelBoss":
            GameController.Instance.mapPos = 13;
            SceneManager.LoadScene("Map");
            break;

            default:
                Debug.LogWarning("Escena no reconocida.");
                break;
        }
        Debug.Log($"New Pos: {GameController.Instance.mapPos}");
    }

    public void DeadPlayer()
    {
        Debug.Log("Losing condition");
        GameController.Instance.mapPos = 0;
        SceneManager.LoadScene("GameLost");
    }
}


