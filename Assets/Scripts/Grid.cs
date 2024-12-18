using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Grid : MonoBehaviour
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
                if (entry.Value.CompareTag("Enemy") && (GetObjectIndex(entry.Value) == 6 + GetObjectIndex(player) || GetObjectIndex(entry.Value) == 9 + GetObjectIndex(player) )&&
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
}


