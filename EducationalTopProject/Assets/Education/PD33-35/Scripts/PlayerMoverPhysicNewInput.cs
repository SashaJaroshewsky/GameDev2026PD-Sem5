using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoverPhysicNewInput : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;

    private Vector2 _movement;
    private bool _jump;
    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Jump.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        _jump = true;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Jump.performed -= ctx => Jump();
    }

    public void Update()
    {
        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 vector3 = new Vector3(_movement.x, 0f, _movement.y);
        _rigidbody.MovePosition(_rigidbody.position + vector3 * _speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if ( _jump && _groundChecker.IsGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        _jump = false;
    }



}
