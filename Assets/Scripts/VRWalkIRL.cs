using UnityEngine;

public class VRWalkIRL : MonoBehaviour
{
    public float scalingFactor = 2f;
    private Vector3 previousHeadsetPosition;
    void Start()
    {
        previousHeadsetPosition = GetHeadsetPosition();
    }
    void Update()
    {
        Vector3 realWorldMovement = GetRealWorldMovement();
        Vector3 scaledMovement = new Vector3(realWorldMovement.x * scalingFactor, realWorldMovement.y, realWorldMovement.z * scalingFactor);
        transform.position += scaledMovement;
        previousHeadsetPosition = GetHeadsetPosition();
    }

    Vector3 GetRealWorldMovement()
    {
        Vector3 headsetPosition = GetHeadsetPosition();
        Vector3 movement = headsetPosition - previousHeadsetPosition;
        return movement;
    }
    Vector3 GetHeadsetPosition()
    {
        return Camera.main.transform.position;
    }
}
