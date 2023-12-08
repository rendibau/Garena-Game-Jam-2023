using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab enemy
    public int numberOfEnemies = 5;  // Jumlah enemy yang akan di-spawn
    public float spawnInterval = 2f;  // Waktu antara spawn enemy
    public float spawnRadius = 5f;  // Radius spawn enemy

    private float timer = 0f;
    private int enemiesSpawned = 0;

    void Update()
    {
        // Jika masih ada enemy yang perlu di-spawn
        if (enemiesSpawned < numberOfEnemies)
        {
            timer += Time.deltaTime;

            // Jika waktu sudah mencapai spawnInterval, spawn enemy
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;  // Reset timer
            }
        }
    }

    void SpawnEnemy()
    {
        // Mendapatkan posisi acak dalam radius spawnRadius
        Vector2 randomSpawnPoint = (Random.insideUnitCircle * spawnRadius) + (Vector2)transform.position;

        // Melakukan spawn enemy di posisi acak
        Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);

        enemiesSpawned++;

        // Jika sudah mencapai jumlah maksimal, hentikan spawning
        if (enemiesSpawned >= numberOfEnemies)
        {
            enabled = false;  // Matikan script
        }
    }
}
