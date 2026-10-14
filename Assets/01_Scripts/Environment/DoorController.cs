using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class DoorController : MonoBehaviour, IInteractable, IInteractionPrompt
{
    [SerializeField] private MonoBehaviour keyProviderSource;
    [SerializeField] private Transform doorPivot;
    [SerializeField] private Vector3 localOpenAxis = Vector3.up;
    [SerializeField] private float openAngleDegrees = 90f;
    [SerializeField, Min(0.01f)] private float openDuration = 0.5f;

    private IKeyProvider keyProvider;
    private Quaternion closedRotation;
    private bool isOpen;
    private bool openingInProgress;

    public bool IsOpen => isOpen;

    public void SetKeyProviderSource(MonoBehaviour source)
    {
        keyProviderSource = source;
        keyProvider = source as IKeyProvider;
    }

    private void Awake()
    {
        if (doorPivot == null)
        {
            doorPivot = transform;
        }

        closedRotation = doorPivot.localRotation;
        keyProvider = keyProviderSource as IKeyProvider;
    }

    private void Start()
    {
        if (keyProvider == null)
        {
            GameManager manager = FindFirstObjectByType<GameManager>();
            keyProvider = manager;
            keyProviderSource = manager;
        }
    }

    public string GetInteractionPrompt(string interactionKeyLabel)
    {
        string keyLabel = string.IsNullOrWhiteSpace(interactionKeyLabel) ? "E" : interactionKeyLabel;
        if (isOpen)
        {
            return "Puerta abierta";
        }

        return HasKey ? keyLabel + " - Abrir puerta" : keyLabel + " - Necesitas la llave";
    }

    public void Interact()
    {
        if (isOpen || openingInProgress)
        {
            return;
        }

        if (!HasKey)
        {
            Debug.Log("Necesitas abrir el cofre y recoger la llave.", this);
            return;
        }

        StartCoroutine(OpenDoor());
    }

    private bool HasKey => keyProvider != null && keyProvider.HasKey;

    private IEnumerator OpenDoor()
    {
        openingInProgress = true;
        Vector3 axis = localOpenAxis.sqrMagnitude > 0f ? localOpenAxis.normalized : Vector3.up;
        Quaternion targetRotation = closedRotation * Quaternion.AngleAxis(openAngleDegrees, axis);
        float duration = Mathf.Max(0.01f, openDuration);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / duration));
            doorPivot.localRotation = Quaternion.Slerp(closedRotation, targetRotation, progress);
            yield return null;
        }

        doorPivot.localRotation = targetRotation;
        openingInProgress = false;
        isOpen = true;
        Debug.Log("Puerta abierta. ¡Escape completado!", this);
    }
}
