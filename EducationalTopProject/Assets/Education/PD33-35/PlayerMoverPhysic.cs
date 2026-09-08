using UnityEngine;

public class PlayerMoverPhysic : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;

    private Vector2 _movement;

    private void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_movement.x, 0f, _movement.y);
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
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
        if (Input.GetKey(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
