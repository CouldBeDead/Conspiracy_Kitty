using UnityEngine;

public class TelekinesisScript : MonoBehaviour
{
    private bool inScene;
    private bool isColliding;
    private bool hasAnObject;

    [SerializeField] private float maxSpeed = 10f;

    private Camera mainCamera;
    private BoxCollider2D boxCollider2D;
    private GameObject otherObject;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Moveable")
        {
            isColliding = true;

            //boxCollider2D = other.gameObject.GetComponent<BoxCollider2D>();

            otherObject = other.gameObject;
        }
    }
    private void OnCollisionExit()
    {
        isColliding = false;
    }

    private void interactingObjects()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isColliding == true)
        {
            if ((Input.GetKeyDown(KeyCode.E) && hasAnObject == false))
            {
                hasAnObject = true;
                //otherObject.transform.position = Vector2.MoveTowards(otherObject.transform.position, mousePosition, moveSpeed * Time.deltaTime);
            }        
        }

        if(hasAnObject == true)
        {
            otherObject.transform.position = mouseWorldPosition();
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
