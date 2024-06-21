using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public Transform cam;
    [SerializeField] CharacterController controller;

    void Update() {
        // Get the input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player
        //transform.Translate(movement * speed * Time.deltaTime);
        controller.Move(-movement * speed * Time.deltaTime);

        // Update the camera position to follow the player
        if (cam != null) {
            Vector3 camPos = transform.position;
            camPos.y = cam.position.y;
            cam.position = camPos;
        }
    }
}
