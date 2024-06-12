using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    [SerializeField]
    private float raycastOffset = 0.1f; // Slightly longer ray to detect collisions earlier

    private bool shouldMove = true;

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        // Calculate the movement step
        Vector3 movement = direction.normalized * speed * Time.deltaTime;

        // Perform the raycast from the front edge of the platform
        Vector3 rayOrigin = transform.position + direction.normalized * (transform.localScale.z / 2);
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, direction, out hit, movement.magnitude + raycastOffset))
        {
            // Stop the platform if a collision is detected
            shouldMove = false;
            Debug.Log("Platform hit: " + hit.collider.name);
        }
        else
        {
            // Move the platform
            transform.position += movement;
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the raycast in the scene view
        Gizmos.color = Color.red;
        Vector3 rayOrigin = transform.position + direction.normalized * (transform.localScale.z / 2);
        Gizmos.DrawRay(rayOrigin, direction.normalized * (speed * Time.deltaTime + raycastOffset));
    }
}
