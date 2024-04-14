using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float minSpawnInterval = 1f; // Minimum spawn interval
    public float maxSpawnInterval = 3f; // Maximum spawn interval

    void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generate a random spawn interval
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Generate a random Y position for the enemy spawn within the screen height
            float spawnYPosition = Random.Range(0f, Screen.height);

            // Convert the screen position to world position
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 2, spawnYPosition, 0));
            spawnPosition.z = 0; // Set the Z position to 0

            // Instantiate an enemy at the calculated spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
