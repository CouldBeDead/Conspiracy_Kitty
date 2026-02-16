using UnityEngine;

public class Moveables : MonoBehaviour
{
    private Vector3 startingPosition;
    //private TelekinesisScript telekinesisScript;
    private GameObject playerObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") transform.position = startingPosition;
    }

    private void Start()
    {
        startingPosition = transform.position;

        //telekinesisScript = GameObject.Find("Player/Square").GetComponent<TelekinesisScript>();
        playerObject = GameObject.Find("Player");
    }
    public void Update()
    {
        if(transform.position.y < (playerObject.transform.position.y - 6f)) transform.position = startingPosition;
    }
}
