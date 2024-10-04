using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float _maxVerticalAngle = 90f;
    [SerializeField] private float _minVerticalAngle = -90f;
    
    [SerializeField] private float _sensitivity = 250.0f;

    private float _cameraAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        _cameraAngle = _cameraPosition.localEulerAngles.x;
    }

    private void Update()
    {
        _cameraAngle -= Input.GetAxis(MouseY);
        _cameraAngle = Mathf.Clamp(_cameraAngle, _minVerticalAngle, _maxVerticalAngle);
        
        _cameraPosition.localEulerAngles = Vector3.right * _cameraAngle;
        
        transform.Rotate(_sensitivity * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);
    }
}