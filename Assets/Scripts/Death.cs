using UnityEngine;

public class Death : MonoBehaviour
{
    private Vector2 respawnPoint;

    void Start() 
    {
        respawnPoint = transform.position; // Set the initial respawn point to the starting position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = respawnPoint; // Respawn the player at the respawn point
        }
    }
}
