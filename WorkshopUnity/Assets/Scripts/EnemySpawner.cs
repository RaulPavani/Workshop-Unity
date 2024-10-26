using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeMinSpawn = 1.5f;
    public float timeMaxSpawn = 4f;
    float timeToSpawn => Random.Range(timeMinSpawn, timeMaxSpawn);

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
