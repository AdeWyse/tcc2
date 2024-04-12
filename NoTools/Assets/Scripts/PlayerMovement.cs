using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movingSpeed = 5f;

    private float screenWidth;
    private float screenHeigth;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenWidth =  Camera.main.orthographicSize * Camera.main.aspect;
        screenHeigth = Camera.main.orthographicSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        KeepInBounds();
    }

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        if(inputHorizontal != 0 || inputVertical != 0)
        {
            rb.velocity = new Vector2(inputHorizontal, inputVertical) * movingSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void KeepInBounds()
    {
        float verticalPosition = gameObject.transform.position.y;
        float horizontalPosition = gameObject.transform.position.x;
        if(verticalPosition < -screenHeigth + 0.5f)
        {
            transform.position = new Vector3(transform.position.x, -screenHeigth + 0.5f, transform.position.z);
        }
        if ( verticalPosition > screenHeigth - 0.5f)
        {
            transform.position = new Vector3(transform.position.x, screenHeigth - 0.5f, transform.position.z);
        }
        if (horizontalPosition < -screenWidth + 0.5f)
        {
            transform.position = new Vector3(-screenWidth + 0.5f, transform.position.y, transform.position.z);
        }
        if (horizontalPosition > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
