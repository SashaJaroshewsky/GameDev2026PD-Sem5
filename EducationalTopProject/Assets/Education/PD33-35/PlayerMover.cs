using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if(movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        transform.Translate(movement  * _speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * _jumpForce * Time.deltaTime);
        }
    }
}
