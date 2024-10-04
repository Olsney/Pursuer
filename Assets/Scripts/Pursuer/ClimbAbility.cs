using UnityEngine;

public class ClimbAbility : MonoBehaviour
{
    [SerializeField] private Pursuer _pursuer;

    private void OnTriggerEnter(Collider other)
    {
        float epsilon = 0.1f;
        
        if (other.bounds.max.y - _pursuer.BoundsMinY >= _pursuer.PlayerStepOffset)
            return;

        Vector3 position = new Vector3(_pursuer.transform.position.x, other.bounds.max.y + _pursuer.BoundsMinY + epsilon,
            _pursuer.transform.position.z);

        _pursuer.transform.position = position;
    }
}