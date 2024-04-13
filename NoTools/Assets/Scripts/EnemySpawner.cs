using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float screenHeigth;
    private float screenWidth;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        screenHeigth = Camera.main.orthographicSize;
        screenWidth = screenHeigth * Camera.main.aspect;
        Invoke("SpawnEnemy", 0.2f);
    }
    private void SpawnEnemy()
    {
        Vector3 startPosition = new Vector3(screenWidth + 2, Random.Range(-screenHeigth, screenHeigth), 0);
        Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        Invoke("SpawnEnemy", Random.Range(1f, 2.0f))
            ;
    }
}
