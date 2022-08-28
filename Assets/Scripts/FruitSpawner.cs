using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay = 0.1f;
    [SerializeField] private float maxDelay = 1f;
    
    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = UnityEngine.Random.Range(minDelay, maxDelay);        
            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(delay / 5f);
            
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
