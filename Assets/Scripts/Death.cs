using UnityEngine;

public class Death : MonoBehaviour
{
    private Vector2 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy body collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enemy bullet trigger hit
        if (other.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint;
    }
}
