using UnityEngine;

public class FootMover : MonoBehaviour
{
    public Vector3 NewTarget { get; set; }

    [SerializeField] private Transform targetPoint;
    [SerializeField] private float distance;
    [SerializeField] private float maxHeightDistance;

    [SerializeField] private float countLerpPosition = 0.4f;
    [SerializeField] private float countLerpHeight = 0.5f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float amplitude = 0.4f;

    private float _currentTime = 1.0f;

    private void Start()
    {
        NewTarget = targetPoint.position;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.up, out RaycastHit hit))
        {
            if (Vector3.Distance(hit.point, -targetPoint.position) > distance)
            {
                _currentTime = 0;
                NewTarget = hit.point;
            }

            if (_currentTime < 1)
            {
                Vector3 footPosition = Vector3.Lerp(targetPoint.position, hit.point, countLerpPosition);
                footPosition.y = Mathf.Lerp(footPosition.y, hit.point.y, countLerpHeight) + Mathf.Sin(_currentTime * Mathf.PI) * amplitude;
                targetPoint.position = footPosition;
                _currentTime += Time.deltaTime * speed;
            }
        }
    }
}
