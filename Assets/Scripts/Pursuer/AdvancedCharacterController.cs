using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AdvancedCharacterController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _jumpForce = 8.0f;
    [SerializeField] private float _slopeForce = 25f;
    [SerializeField] private float _slopeRayLength = 1.5f;

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _verticalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        if (_controller.isGrounded)
        {
            SetMoveDirection();
            
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        _moveDirection.y -= _gravity * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * Time.fixedDeltaTime);
        
        Slope();
    }

    private void Jump()
    {
        _moveDirection.y = _jumpForce;
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        float verticalInput = Input.GetAxis(Vertical);

        Vector3 inputDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        inputDirection = transform.TransformDirection(inputDirection);

        _moveDirection = inputDirection * _speed;
    }

    private void Slope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _slopeRayLength) == false)
            return;
        
        if (Vector3.Angle(hit.normal, Vector3.up) > _controller.slopeLimit)
        {
            _moveDirection.x += (1f - hit.normal.y) * hit.normal.x * _slopeForce;
            _moveDirection.z += (1f - hit.normal.y) * hit.normal.z * _slopeForce;
            _moveDirection.y -= _slopeForce;
        }
    }
}