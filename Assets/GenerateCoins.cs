using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoins : MonoBehaviour
{
    public GameObject enemy;
    public GameObject friend;
    public GameObject terrainObject;

    public int numberOfEnemies;
    public int numberOfFriends;
    public int numberOfTerrainObjects;

    public GameObject terrain;

    void Start()
    {
        
    }

    void Update()
    {
        OnSpawnAPrefab();
    }

    [SerializeField] private GameObject prefab;

    [SerializeField] private Vector2 spawnPosition;

    [SerializeField] private bool random;

    public void OnSpawnAPrefab()
    {
        float x = Random.Range(-8, 8);
        float y = Random.Range(-4, 4);

        Instantiate(prefab, new Vector2(x, y), Quaternion.identity);


    }
}
