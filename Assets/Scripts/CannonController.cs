using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Launch Settings")]
    public float launchSpeed = 12f;

    [Header("Cannon")]
    public float angle = 30f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Convert angle from degrees to radians
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Calc hor and ver velocity
        float velocityX = Mathf.Cos(angleInRadians) * launchSpeed;
        float velocityY = Mathf.Sin(angleInRadians) * launchSpeed;

        // Create projectile
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

    
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply calc velocity
        rb.velocity = new Vector2(velocityX, velocityY);
    }
}