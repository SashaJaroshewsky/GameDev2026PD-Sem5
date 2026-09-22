using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded {  get; private set; }
    
    private void Update()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundCheckDistance);
    }
}
