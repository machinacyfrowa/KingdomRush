using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject path;
    public float spawnInterval = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnInterval);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().path = path;
    }
}
