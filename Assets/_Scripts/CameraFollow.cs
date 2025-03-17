using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float followSpeed;
    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        if (!target) return;
        transform.position = Vector3.Lerp
            (transform.position, 
             new Vector3(
                 Mathf.Clamp(target.position.x, minX, maxX),
                 Mathf.Clamp(target.position.y, minY, maxY), 
                 -10),
             followSpeed * Time.fixedDeltaTime
            );
    }
}
