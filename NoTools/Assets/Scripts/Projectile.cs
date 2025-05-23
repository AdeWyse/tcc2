using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float movingSpeed = 5;
    public float movingDirection = 1;

    private float screenWidth;

    public AudioSource audioImpact;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        DestroyOutOfBounds();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movingSpeed * movingDirection);
    }

    private void DestroyOutOfBounds()
    {
        if(transform.position.x > screenWidth || transform.position.x < -screenWidth)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            audioImpact = GameObject.Find("Impact").GetComponent<AudioSource>();
            audioImpact.Play();
        }
        Destroy(gameObject);
    }
}
