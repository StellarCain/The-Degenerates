using UnityEngine;

public class SharkChase : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float moveSpeed = 5f; // Shark's movement speed
    public float rayCastDistance = 2f; // Distance for raycasting to avoid obstacles
    public LayerMask obstacleLayer; // Layer mask for obstacles

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 targetDirection = (player.position - transform.position).normalized;

            // Cast rays to check for obstacles in the shark's path
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, rayCastDistance, obstacleLayer);

            if (hit.collider != null)
            {
                // If obstacle detected, adjust target direction away from the obstacle
                targetDirection = Vector3.Reflect(targetDirection, hit.normal);
            }

            // Move the shark towards the adjusted target direction
            rb.velocity = targetDirection * moveSpeed;
            transform.rotation = Quaternion.Euler(targetDirection);
        }
    }
}
