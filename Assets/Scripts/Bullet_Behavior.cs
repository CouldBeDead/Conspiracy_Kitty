using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet2D : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = (Vector2)transform.right * speed; // assumes bullet faces right
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Optional: ignore enemy collider by tag/layer if you want
        // if (other.CompareTag("Enemy")) return;

        Destroy(gameObject);
    }
}
