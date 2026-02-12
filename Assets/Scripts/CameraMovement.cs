using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Adjust the offset as needed, -10f is standard for 2D

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to the player's position plus the offset
            transform.position = target.position + offset;
        }
    }
}
