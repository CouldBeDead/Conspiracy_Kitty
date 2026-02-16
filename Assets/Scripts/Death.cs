using UnityEngine;

public class Death : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip death;
    private Vector2 respawnPoint;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        respawnPoint = transform.position; // Set the initial respawn point to the starting position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(death); 
            transform.position = respawnPoint; // Respawn the player at the respawn point
        }
    }
}
