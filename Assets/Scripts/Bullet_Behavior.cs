using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet2D : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 12f;
    public float lifeTime = 5f;

    [Header("Bounce")]
    public int maxBounces = 3;
    public float bounceDamping = 1f;        // 1 = perfect bounce, 0.9 loses speed
    public LayerMask wallLayers;            // set this to your "Wall" layer(s)

    [Header("Visual")]
    public bool faceVelocity = true;

    Rigidbody2D rb;
    Vector2 lastVelocity;
    int bounces;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        // helps prevent “sticky sliding”
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
    }

    void Start()
    {
        rb.linearVelocity = (Vector2)transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        // Store velocity BEFORE physics resolves a collision
        lastVelocity = rb.linearVelocity;
    }

    void Update()
    {
        if (faceVelocity && rb.linearVelocity.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only bounce off walls (set wallLayers in Inspector)
        if ((wallLayers.value & (1 << collision.gameObject.layer)) == 0)
        {
            Destroy(gameObject);
            return;
        }

        if (bounces >= maxBounces)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 normal = collision.contacts[0].normal;

        // Reflect using LAST velocity (pre-collision), not the already-resolved velocity
        Vector2 reflected = Vector2.Reflect(lastVelocity.normalized, normal);

        rb.linearVelocity = reflected * (lastVelocity.magnitude * bounceDamping);

        bounces++;
    }
}
