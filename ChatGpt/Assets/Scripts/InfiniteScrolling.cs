using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    public float scrollSpeed = 1f; // Adjust this to control the speed of scrolling
    private float spriteWidth;
    private Transform cameraTransform;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x;

        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Calculate the distance to move based on scrollSpeed and deltaTime
        float moveDistance = scrollSpeed * Time.deltaTime;

        // Move the background to the left
        transform.Translate(Vector3.left * moveDistance);

        // Check if the background has scrolled off-screen
        if (transform.position.x < cameraTransform.position.x - spriteWidth)
        {
            // Reposition the background to the right of the other background
            transform.position = new Vector3(transform.position.x + spriteWidth * 2, transform.position.y, transform.position.z);
        }
    }
}
