using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Vector3 _combinedVelocity;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += _combinedVelocity * Time.deltaTime;
    }

    public void SetDirection(Vector2 movementDirection)
    {
        _combinedVelocity = movementDirection * movementSpeed;
    }
}
