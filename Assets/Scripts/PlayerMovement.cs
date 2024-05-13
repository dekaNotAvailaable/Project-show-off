using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
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
    void Update()
    {
        Debug.Log(playerControl.ReadValue<Vector3>());
        rb.velocity = playerControl.ReadValue<Vector3>() * moveSpeed;
    }
    private void CharacterMovementStart(InputAction.CallbackContext value)
    {




    }
}
