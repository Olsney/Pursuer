using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public float StepOffset => _characterController.stepOffset;
}