using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    private const KeyCode AddForceButton = KeyCode.E;

    [SerializeField] private float _force = 10f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(AddForceButton))
        {
            _rigidbody.AddForce(Vector3.down * _force);
        }
    }
}
