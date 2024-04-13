using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movingSpeed = 5;

    private float screenWidth;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        movingSpeed = Random.Range(3.0f, 6.0f);
        Invoke("Shoot", 0.2f);
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

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().movingSpeed = movingSpeed + 2f;
        Invoke("Shoot", Random.Range(1.0f, 3.0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 6) // 3 - Player | 6 - PlayerProjectile
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            player.points += 5;
            Destroy(gameObject);
        }
           
    }
}
