using UnityEditor.UIElements;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    [Range(0, 10)]
    public float smoothTime;

    public Vector3 pos1, pos2;

    void Start()
    {

    }
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = target.position + offSet;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
