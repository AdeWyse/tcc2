using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movingSpeed = 5;

    private float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        movingSpeed = Random.Range(3.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        DestroyOutOfBounds();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movingSpeed);
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.x < -screenWidth)
        {
            Destroy(gameObject);
        }
    }
}
