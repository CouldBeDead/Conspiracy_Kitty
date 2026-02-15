using UnityEngine;

public class ShoulderAimAndShoot2D : MonoBehaviour
{
    [Header("Aim References")]
    public Transform player;
    public Transform gun;          // Child gun object
    public Transform firePoint;    // Where bullets spawn (child of gun)

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float shootRange = 6f;
    public float fireRate = 3f; // bullets per second

    [Header("Optional")]
    public bool flipWithEnemyScale = true;

    float nextShotTime = 0f;

    void Update()
    {
        if (player == null || gun == null || firePoint == null || bulletPrefab == null) return;

        // Aim
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Optional flip handling
        if (flipWithEnemyScale)
        {
            if (transform.lossyScale.x < 0)
                gun.localScale = new Vector3(1, -1, 1);
            else
                gun.localScale = new Vector3(1, 1, 1);
        }

        // Shoot if close enough + fire rate cooldown
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= shootRange && Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + (1f / fireRate);
        }
    }

    void Shoot()
    {
        // Spawn bullet facing firePoint's direction
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
