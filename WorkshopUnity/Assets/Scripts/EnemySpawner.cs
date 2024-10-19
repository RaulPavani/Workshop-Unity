using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeToSpawn = 3f;

    public UnityEvent spawnEvent;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", timeToSpawn, timeToSpawn);
    }

    public void SpawnEnemy()
    {
        GameObject gameObject = Instantiate(enemyPrefab,
                                            transform.position,
                                            Quaternion.identity);
        spawnEvent.Invoke();
    }
}
