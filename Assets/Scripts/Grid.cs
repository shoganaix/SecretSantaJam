using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Grid : MonoBehaviour
{
    private Dictionary<int, GameObject> gridOccupants;
    private int gridSize;

    public GameObject playerPrefab;
    public GameObject player;
    public GameObject[] enemies;

    void Start()
    {
        gridSize = transform.childCount;
        gridOccupants = new Dictionary<int, GameObject>();

        SpawnPlayer(0);
        SetEnemies();
    }

    private void SpawnPlayer(int startIndex)
    {
        Transform spawnPosition = transform.GetChild(startIndex);
        player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        gridOccupants[startIndex] = player;
    }

    private void SetEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            int enemyGridIndex = gridSize / 2 + enemies[i].GetComponent<Enemy>().initPos;
            Transform spawnPosition = transform.GetChild(enemyGridIndex);

            enemies[i].transform.position = spawnPosition.position;
            enemies[i].GetComponent<Enemy>().id = i + 1;

            gridOccupants[enemyGridIndex] = enemies[i];
        }
    }


    public void Move(int direction)
    {
        int currentIndex = GetObjectIndex(player);
        int newIndex = currentIndex + direction;

        if (newIndex >= 0 && newIndex < gridSize / 2)
        {
            MoveObject(currentIndex, newIndex, player);
        }
    }

    private int GetObjectIndex(GameObject obj)
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
            Debug.Log("Action " + newIndex);
            gridOccupants[100] = existingObj;
        }
        gridOccupants[newIndex] = obj;

        obj.transform.position = transform.GetChild(newIndex).position;
    }

    public void MeleeDamage(int id)
    {

    }


}


