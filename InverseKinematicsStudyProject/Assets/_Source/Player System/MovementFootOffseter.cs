using UnityEngine;

public class MovementFootOffseter : MonoBehaviour
{
    [SerializeField] private float movementOffsetAmount;
    [SerializeField] private FootMover[] targets;

    private Vector3[] _defaultPositions;

    private void Start()
    {
        _defaultPositions = new Vector3[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            _defaultPositions[i] = targets[i].transform.localPosition;
        }
    }

    public void SetMovementOffset(Vector3 movementOffset)
    {
        Vector3 actualMovementOffset = movementOffset.normalized * movementOffsetAmount;

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].transform.localPosition = _defaultPositions[i] + actualMovementOffset;

            if(actualMovementOffset == Vector3.zero)
            {
                if (i % 2 == 0)
                {
                    targets[i].ForceMove();
                }
                else
                {
                    targets[i].ForceStop();
                }
            }
            else
            {
                targets[i].ForceMove();
            }
        }
    }
}
