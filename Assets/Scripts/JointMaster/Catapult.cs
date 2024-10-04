using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private float UpperBaseSpring = 20f;
    [SerializeField] private float LowerBaseSpring = 10f;

    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Rigidbody _lowerBase;
    [SerializeField] private Rigidbody _upperBase;
    [SerializeField] private Launcher _laucnher;

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            _springJoint.connectedBody = _upperBase;
            _springJoint.spring = UpperBaseSpring;
        }

        if (Input.GetKey(KeyCode.O))
        {
            _springJoint.connectedBody = _lowerBase;
            _springJoint.spring = LowerBaseSpring;
            _laucnher.TakeBomb();
        }
    }
}