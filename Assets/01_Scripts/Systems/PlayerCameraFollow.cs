using UnityEngine;

[DisallowMultipleComponent]
public sealed class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 localOffset = new Vector3(0f, 1f, -2f);
    [SerializeField] private float lookHeight = -0.1f;
    [SerializeField, Min(0f)] private float followSpeed = 12f;

    public void SetTarget(Transform followTarget)
    {
        target = followTarget;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = target.position + target.rotation * localOffset;
        float blend = followSpeed <= 0f ? 1f : 1f - Mathf.Exp(-followSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, blend);
        transform.LookAt(target.position + Vector3.up * lookHeight);
    }
}
