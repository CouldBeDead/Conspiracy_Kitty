using UnityEngine;

public class Moveables : MonoBehaviour
{
    private Vector3 startingPosition;
    private TelekinesisScript telekinesisScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") transform.position = startingPosition;
    }

    private void Start()
    {
        startingPosition = transform.position;

        telekinesisScript = GameObject.Find("Player/Square").GetComponent<TelekinesisScript>();
    }
    private void Update()
    {
        if(transform.position.y < -2) startingPosition = transform.position;
    }
}
