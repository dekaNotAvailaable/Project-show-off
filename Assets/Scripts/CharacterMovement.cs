using System; // Make sure to include System namespace for the Action delegates
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //-------public ----------//
    public float moveSpeed = 10f;
    public float jumpCap;
    public float gravityForce = 8f;
    public float jumpForceIncrement = 5f;
    public float arcValue = 0.5f;
    public float horzontalCap;
    public int _playerNumber;
    public Action OnJump;
    public Action OnJumpPressed;
    [HideInInspector]
    public bool _stateChange;

    // Animator reference
    public Animator characterAnimator;

    //-------private--------//
    //private InputControls _input;
    private GameObject _spawnPoint;
    private float _horitzontalCapLeft;
    private Rigidbody _rb;
    private float _jumpForce;
    private Vector3 _moveVec = Vector3.zero;
    private Vector3 _jumpMoveVec = Vector3.zero;
    private Vector3 _gravity;
    private bool _isJumpPressed;
    private bool isDetectingInput = true;
    private float _groundCheckDistance = 2f;

    private void Awake()
    {
        // _input = new InputControls();
        _rb = GetComponent<Rigidbody>();
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void Start()
    {
        _gravity = new Vector3(0f, gravityForce, 0f);
        jumpCap *= 10f;
        _horitzontalCapLeft = horzontalCap * -1;
    }

    public bool IsGrounded()
    {
        float capsuleHeight = GetComponent<CapsuleCollider>().height;
        float radius = GetComponent<CapsuleCollider>().radius;
        Vector3 capsuleCenter = transform.position + GetComponent<CapsuleCollider>().center;
        Vector3 halfExtents = new Vector3(radius, capsuleHeight / 2f - radius, radius);
        return Physics.BoxCast(capsuleCenter, halfExtents, Vector3.down, Quaternion.identity, _groundCheckDistance);
    }

    private void OnEnable()
    {
        //_input.Enable();

        //if (_playerNumber == 1)
        //{
        //    _input.bindingMask = new InputBinding { groups = "Control" };
        //}
        //else
        //{
        //    _input.bindingMask = new InputBinding { groups = "keyboard" };
        //}

        //_input.Player.Movement.performed += MovementStart;
        //_input.Player.Movement.canceled += MovementEnd;
        //_input.Player.Jump.performed += JumpReleased;
    }

    private void OnDisable()
    {
        //_input.Disable();
        //_input.Player.Movement.performed -= MovementStart;
        //_input.Player.Movement.canceled -= MovementEnd;
        //_input.Player.Jump.performed -= JumpReleased;
    }

    private void JumpReleased(InputAction.CallbackContext context)
    {
        if (!isDetectingInput)
        {
            return;
        }

        Jump();
        _jumpMoveVec = Vector3.zero;
    }

    private void MovementStart(InputAction.CallbackContext value)
    {
        if (!isDetectingInput)
        {
            return;
        }
        _moveVec = value.ReadValue<Vector3>();
    }

    private void MovementEnd(InputAction.CallbackContext value)
    {
        _moveVec = Vector3.zero;
    }

    private void Jump()
    {
        OnJump?.Invoke();
        if (IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _rb.AddForce(Vector3.forward * _jumpMoveVec.z, ForceMode.Impulse);
            // if (characterAnimator != null)  
            // characterAnimator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        //Movement();
    }

    //private void Movement()
    //{
    //    _rb.rotation = _moveVec.z < 0 ? Quaternion.Euler(Vector3.zero) : (_moveVec.z > 0 ? Quaternion.Euler(new Vector3(0, 180, 0)) : _rb.rotation);
    //    if (_input.Player.Jump.ReadValue<Vector3>().y == 1)
    //    {
    //        if (!_isJumpPressed)
    //        {
    //            OnJumpPressed?.Invoke();
    //            _isJumpPressed = true;
    //        }
    //        _jumpForce += jumpForceIncrement;
    //        if (_moveVec.z < 0) { _jumpMoveVec.z -= arcValue; }
    //        else if (_moveVec.z > 0) { _jumpMoveVec.z += arcValue; }
    //        else if (_moveVec.z == 0) { _jumpMoveVec = Vector3.zero; }
    //        if (_jumpForce >= jumpCap) { _jumpForce = jumpCap; }
    //        if (_jumpMoveVec.z >= horzontalCap) { _jumpMoveVec.z = horzontalCap; }
    //        else if (_jumpMoveVec.z <= _horitzontalCapLeft) { _jumpMoveVec.z = _horitzontalCapLeft; }
    //    }
    //    else { _isJumpPressed = false; }

    //    if (IsGrounded())
    //    {
    //        if (!_isJumpPressed)
    //        {
    //            _jumpMoveVec = _moveVec;
    //            _rb.velocity = new Vector3(_moveVec.x, _rb.velocity.y, _moveVec.z * moveSpeed);
    //            // Set walking animation
    //            if (characterAnimator != null)
    //                characterAnimator.SetBool("isMoving", _moveVec.z != 0);
    //        }
    //        else
    //        {
    //            _rb.velocity = new Vector3(_moveVec.x, _rb.velocity.y, _moveVec.z * 0);
    //            // Reset walking animation
    //            if (characterAnimator != null)
    //                characterAnimator.SetBool("isMoving", false);
    //        }
    //    }
    //    else
    //    {
    //        _rb.velocity -= _gravity;
    //        _jumpForce = 0;
    //        // Reset walking animation
    //        if (characterAnimator != null)
    //            characterAnimator.SetBool("isMoving", false);
    //    }
    //}

    public void StopDetectingInput()
    {
        isDetectingInput = false;
        _moveVec = Vector3.zero;
        _jumpMoveVec = Vector3.zero;
        _jumpForce = 0;
    }

    public void StartDetectingInput()
    {
        _jumpMoveVec = Vector3.zero;
        _moveVec = Vector3.zero;
        _jumpForce = 0;
        isDetectingInput = true;
    }
}
