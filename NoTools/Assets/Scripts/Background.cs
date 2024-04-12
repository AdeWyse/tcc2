using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float movingSpeed = 5f;
    private float screenPosition;
    // Start is called before the first frame update
    void Start()
    {
        screenPosition = Camera.main.orthographicSize * Camera.main.aspect * 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
        RestartBackground();
    }

    private void MoveBackground()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movingSpeed);
    }

    private void RestartBackground()
    {   
       
        if(transform.position.x <= -screenPosition)
        {
            transform.position = new Vector3(screenPosition, transform.position.y, transform.position.z);
        }
    }
}
