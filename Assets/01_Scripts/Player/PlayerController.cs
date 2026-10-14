using UnityEngine;

[DisallowMultipleComponent]
public sealed class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0f)] private float speed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0f,
            Input.GetAxisRaw("Vertical"));

        if (movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }

        if (movement.sqrMagnitude <= 0f)
        {
            return;
        }

        transform.position += movement * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
    }
}
