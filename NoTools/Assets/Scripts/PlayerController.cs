using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private bool canShoot = true;

    public int life = 3;
    public int points = 0;

    public ScenesController scenesController;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        CheckPoints();
    }

    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                canShoot = false;
                Invoke("UnlockShoot", 0.3f);
            }
        }
       
    }

    private void UnlockShoot()
    {
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 8)// 7 = Enemy | 8 = EnemyProjectile
        {
            Destroy(collision.gameObject);
            life--;
            CheckAlive();

        }
    }

    private void CheckAlive()
    {
        if(life <= 0)
        {
            scenesController.ChangeScene("GameOver");
        }
    }

    private void CheckPoints()
    {
        if(points >= 100)
        {
            scenesController.ChangeScene("Win");
        }
    }
}
