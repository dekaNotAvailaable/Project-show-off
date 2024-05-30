using UnityEngine;

public class VRWalkIRL : MonoBehaviour
{
    public Transform vrCamera; // Reference to the VR camera
    public float speed = 1.0f; // Movement speed multiplier

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = vrCamera.position;
    }

    void Update()
    {
        Vector3 deltaPosition = vrCamera.position - previousPosition;
        deltaPosition.y = 0; // Ignore vertical movement for walking

        transform.position += deltaPosition * speed;
        previousPosition = vrCamera.position;
    }
}
