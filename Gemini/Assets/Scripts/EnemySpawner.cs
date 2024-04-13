using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnIntervalMin = 1f; // Minimum time between spawns (seconds)
    public float spawnIntervalMax = 3f; // Maximum time between spawns (seconds)
    public float spawnYMin = -5f; // Minimum Y position for spawning (world units)
    public float spawnYMax = 5f; // Maximum Y position for spawning (world units)
    public float spawnOffsetX = 10f; // Offset from the right edge of the camera (world units)
    private Camera mainCamera; // Reference to the main camera
    private float nextSpawnTime; // Time of the next enemy spawn

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Calculate initial spawn time
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update() // Update for spawning
    {
        if (Time.time >= nextSpawnTime)
        {
            // Spawn a new enemy
            SpawnEnemy();

            // Calculate the next spawn time
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    void SpawnEnemy()
    {
        // Get random Y position within the specified range
        float randomY = Random.Range(spawnYMin, spawnYMax);

        // Calculate spawn position just outside the camera view on the right
        Vector2 spawnPosition = new Vector2(mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect + spawnOffsetX, randomY);

        // Instantiate the enemy prefab
        Instantiate(enemyPrefab, spawnPosition, transform.rotation);
    }
}
