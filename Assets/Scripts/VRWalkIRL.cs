using UnityEngine;

public class VRWalkIRL : MonoBehaviour
{
    public float scalingFactor = 2f; // Adjust this value to change the scaling factor

    // Update is called once per frame
    void Update()
    {
        // Example: Get real-world movement from VR headset position
        Vector3 realWorldMovement = GetRealWorldMovement();

        // Apply scaling factor
        Vector3 scaledMovement = realWorldMovement * scalingFactor;

        // Update player position in Unity
        transform.position += scaledMovement;
    }

    // Example method to get real-world movement (you need to implement this according to your VR system)
    Vector3 GetRealWorldMovement()
    {
        // Example: Get movement from VR headset position
        Vector3 headsetPosition = GetHeadsetPosition();
        Vector3 previousHeadsetPosition = GetPreviousHeadsetPosition();

        // Calculate movement vector
        Vector3 movement = headsetPosition - previousHeadsetPosition;

        // Return movement vector
        return movement;
    }

    // Example methods to get VR headset position (you need to implement these according to your VR system)
    Vector3 GetHeadsetPosition()
    {
        // Example: Get headset position from VR headset tracking system
        return Camera.main.transform.position;
    }

    Vector3 GetPreviousHeadsetPosition()
    {
        // Example: Get previous headset position from a variable
        // You might want to use a variable to store the previous position for calculating movement
        // For simplicity, we'll return zero vector as previous position
        return Vector3.zero;
    }
}
