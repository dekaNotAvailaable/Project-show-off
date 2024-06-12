using UnityEngine;

public class movegradualy : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f; // Maximum speed the character can reach.
    [SerializeField] private float accelerationRate = 2f; // Rate at which speed increases per second.

    private float currentSpeed = 0f; // Current speed of the character.
    private Vector3 moveDirection = Vector3.forward; // Movement direction.

    private void Update()
    {
        // Read input for movement (e.g., WASD keys or joystick).
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on input.
        moveDirection = new Vector3(inputHorizontal, 0f, inputVertical).normalized;

        // Apply gradual acceleration to the current speed.
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationRate * Time.deltaTime, 0f, maxSpeed);

        // Apply movement.
        Vector3 movement = moveDirection * currentSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
