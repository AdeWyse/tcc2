using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = -0.5f; // Adjust speed for desired scrolling speed (negative for right-to-left)
    public Transform background1; // Reference to B1 background object
    public Transform background2; // Reference to B2 background object
    public Camera mainCamera; // Reference to the main camera

    private float backgroundWidth; // Stores the width of a single background sprite
    private Vector3 background1InitialPosition; // Stores B1's initial position
    private Vector3 background2InitialPosition; // Stores B2's initial position
    private Vector3 viewportMinBounds; // Stores the minimum bounds of the camera viewport

    void Start()
    {
        backgroundWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        // Store initial positions of both backgrounds
        background1InitialPosition = background1.position;
        background2InitialPosition = background2.position;

        // Optionally, get the main camera for viewport check
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Calculate viewport minimum bounds (assuming camera is orthographic)
        viewportMinBounds = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
    }

    void Update()
    {
        // Update both backgrounds' x-positions based on scroll speed and time
        background1.Translate(new Vector3(scrollSpeed * Time.deltaTime, 0f, 0f));
        background2.Translate(new Vector3(scrollSpeed * Time.deltaTime, 0f, 0f));

        // Check if B1 is off-screen and invisible 
        if (background1.position.x < viewportMinBounds.x * 2)
        {
            // Teleport B1 to the right of B2 (using stored initial positions)
            background1.position = new Vector3 (background2InitialPosition.x, background1.position.y, background1.position.z);
        }

        // Check if B2 is off-screen and invisible
        if (background2.position.x < viewportMinBounds.x * 2)
        {
            // Teleport B2 to the right of the combined width (using stored positions)
            background2.position = background2InitialPosition;
        }
    }
}
