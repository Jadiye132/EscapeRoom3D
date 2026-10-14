using UnityEngine;

public class OldDoorController : MonoBehaviour
{
    private bool isOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        transform.localRotation =
            Quaternion.Euler(0f, isOpen ? 90f : 0f, 0f);

        Debug.Log(isOpen ? "Door opened" : "Door closed");
    }
}