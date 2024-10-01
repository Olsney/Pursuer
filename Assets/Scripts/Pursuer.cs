using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public float BoundsMinY => _collider.bounds.min.y;
    public float PlayerStepOffset => _player.StepOffset;
}