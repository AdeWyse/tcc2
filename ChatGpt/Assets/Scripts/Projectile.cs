using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Destroy the projectile
        Destroy(gameObject);
    }

    private void Update()
    {
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}

