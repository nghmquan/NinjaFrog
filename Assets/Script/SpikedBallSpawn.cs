using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallSpawn : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnRate = 2f;
    public float spawnDelay = 1f;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnRate);
    }

    void SpawnObject()
    {
        float randomY = Random.Range(-2f, 2f); // Vị trí ngẫu nhiên theo trục x
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
