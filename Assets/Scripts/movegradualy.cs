using UnityEngine;

public class movegradualy : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float accelerationRate = 2f;

    private float currentSpeed = 0f;
    private Vector3 moveDirection = Vector3.forward;

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(inputHorizontal, 0f, inputVertical).normalized;
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationRate * Time.deltaTime, 0f, maxSpeed);
        Vector3 movement = moveDirection * currentSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
