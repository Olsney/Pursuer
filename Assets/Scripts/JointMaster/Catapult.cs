using UnityEngine;

public class Catapult : MonoBehaviour
{
    private const KeyCode SpawnKey = KeyCode.O;
    private const KeyCode PushLauncherKey = KeyCode.P;
    
    [SerializeField] private float _upperBaseSpring = 20f;
    [SerializeField] private float _lowerBaseSpring = 10f;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Rigidbody _lowerBase;
    [SerializeField] private Rigidbody _upperBase;
    [SerializeField] private Launcher _laucnher;

    private void Update()
    {
        if (Input.GetKey(PushLauncherKey))
        {
            _springJoint.connectedBody = _upperBase;
            _springJoint.spring = _upperBaseSpring;
        }

        if (Input.GetKey(SpawnKey))
        {
            _springJoint.connectedBody = _lowerBase;
            _springJoint.spring = _lowerBaseSpring;
            _laucnher.TakeBomb();
        }
    }
}