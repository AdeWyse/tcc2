using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                canShoot = false;
                Invoke("UnlockShoot", 0.3f);
            }
        }
       
    }

    private void UnlockShoot()
    {
        canShoot = true;
    }
}
