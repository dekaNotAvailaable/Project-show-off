using UnityEngine;

public class FloatingPlank : MonoBehaviour
{
    // Amplitude of the floating motion
    public float amplitude = 0.5f;
    // Frequency of the floating motion
    public float frequency = 1f;

    // Initial position of the cube
    private Vector3 initialPosition;

    void Start()
    {
        // Record the initial position of the cube
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position
        float newY = initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Set the new position of the cube
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
