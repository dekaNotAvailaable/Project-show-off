using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

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

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, movement.magnitude))
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
        Gizmos.DrawRay(transform.position, direction.normalized * speed * Time.deltaTime);
    }
}
