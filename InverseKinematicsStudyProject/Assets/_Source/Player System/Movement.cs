using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private MovementFootOffseter footOffseter;

    private CharacterController _characterController;

    private Vector3 _movement;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _characterController.SimpleMove(_movement);
    }

    public void SetDirection(Vector2 direction)
    {
        direction = direction.normalized;
        _movement.x = direction.x * movementSpeed;
        _movement.z = direction.y * movementSpeed;

        Vector3 footOffset = new Vector3(direction.x, 0, _movement.z);
        footOffseter.SetMovementOffset(footOffset);
    }

}
