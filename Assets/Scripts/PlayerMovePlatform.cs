using UnityEngine;

public class PlayerMovePlatform : MonoBehaviour
{
    private Transform platform;
    private Vector3 lastPlatformPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            platform = other.transform;
            lastPlatformPosition = platform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            platform = null;
        }
    }

    void LateUpdate()
    {
        if (platform != null)
        {
            Vector3 platformMovement = platform.position - lastPlatformPosition;
            transform.position += platformMovement;
            lastPlatformPosition = platform.position;
        }
    }
}
