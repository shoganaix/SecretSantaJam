using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Transform[] gridObjects;
    private List<Transform> playerArea = new List<Transform>();
    private List<Transform> enemyArea = new List<Transform>();

    public GameObject playerPrefab;
    public GameObject[] enemyPrefab;

    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        LoadGridObjects();
        DivideGridAreas();
        SpawnPlayer();
        SpawnEnemies();
    }
    void LoadGridObjects()
    {
        gridObjects = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            gridObjects[i] = transform.GetChild(i);
    }

    void DivideGridAreas()
    {
        for (int i = 0; i < gridObjects.Length; i++)
        {
            if (i < gridObjects.Length / 2)
                playerArea.Add(gridObjects[i]);
            else
                enemyArea.Add(gridObjects[i]);
        }
    }

    void SpawnPlayer()
    {
        Transform spawnPos = playerArea[0];
        player = Instantiate(playerPrefab, spawnPos.position, Quaternion.identity);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            int randomIndex = Random.Range(0, enemyArea.Count);
            Transform spawnPos = enemyArea[randomIndex];
            GameObject enemy = Instantiate(enemyPrefab[i], spawnPos.position, Quaternion.identity);
            enemies.Add(enemy);
        }
    }
}


