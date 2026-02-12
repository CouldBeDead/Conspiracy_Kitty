using UnityEngine;

public class TelekinesisScript : MonoBehaviour
{
    private bool inScene;
    private bool isColliding;
    private bool hasAnObject;

    //[SerializeField] private float maxSpeed = 10f;

    private Camera mainCamera;
    private BoxCollider2D boxCollider2D;
    private GameObject otherObject;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Moveable")
        {
            isColliding = true;

            otherObject = other.gameObject;
            boxCollider2D = otherObject.GetComponent<BoxCollider2D>();

            Debug.Log("Colliding");
        }
    }
    private void OnCollisionExit2D()
    {
        isColliding = false;
    }

    private void interactingObjects()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isColliding == true && hasAnObject == false)
        {
            boxCollider2D.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hasAnObject = !hasAnObject;
                isColliding = false;
            }        
        }

        if (hasAnObject == true)
        {
            otherObject.transform.position = mouseWorldPosition();
            boxCollider2D.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                hasAnObject = !hasAnObject;
                boxCollider2D.enabled = true;
            }
        }
    }
    private Vector2 mouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        interactingObjects();
    }
}
