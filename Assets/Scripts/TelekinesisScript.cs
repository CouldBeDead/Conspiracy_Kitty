using UnityEngine;

public class telekinesisScript : MonoBehaviour
{
    public float forceAmount = 50f;
    private Rigidbody2D rb; 
    
    // This public bool allows other scripts to "turn on" the drag
    public bool IsBeingDragged { get; set; }

    void Start() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
    {
        if (IsBeingDragged)
        {
            print("Dragging " + gameObject.name);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 direction = (worldMousePos - transform.position).normalized;
            rb.AddForce(direction * forceAmount);
        }
    }
}
