using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float gravity;
    private PlayerInput input;
    private InputAction playerControl;
    // private Vector2 moveVec;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        playerControl = input.actions.FindAction("move");
    }
    private void OnEnable()
    {
        // moveVec = playerControl.ReadValue<Vector2>();
        // playerControl.performed += CharacterMovementStart;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(playerControl.ReadValue<Vector3>());
        CharacterMovement();
        GravityEffect();
    }
    private void GravityEffect()
    {
        Vector3 gravityForce = gravity * Physics.gravity * rb.mass;

        // Apply the force to the Rigidbody
        rb.AddForce(gravityForce, ForceMode.Force);
    }
    private void CharacterMovement()
    {
        rb.velocity = playerControl.ReadValue<Vector3>() * moveSpeed;

    }
}
