using UnityEngine;

[DisallowMultipleComponent]
public sealed class PlayerInteraction : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float interactionDistance = 4f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactionLayers = ~0;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    private IInteractable currentTarget;
    private Component currentTargetComponent;

    private void Update()
    {
        UpdateTarget();

        if (Input.GetKeyDown(interactionKey))
        {
            TryInteract();
        }
    }

    public void SetPlayerCamera(Camera cameraToUse)
    {
        playerCamera = cameraToUse;
    }

    public bool TryInteract()
    {
        if (currentTarget == null)
        {
            return false;
        }

        currentTarget.Interact();
        return true;
    }

    private void UpdateTarget()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        if (playerCamera == null)
        {
            SetTarget(null, null);
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(
            ray,
            interactionDistance,
            interactionLayers,
            QueryTriggerInteraction.Ignore);
        System.Array.Sort(hits, (left, right) => left.distance.CompareTo(right.distance));

        for (int i = 0; i < hits.Length; i++)
        {
            Collider hitCollider = hits[i].collider;
            if (hitCollider == null || hitCollider.transform == transform || hitCollider.transform.IsChildOf(transform))
            {
                continue;
            }

            if (TryFindInteractable(hitCollider, out IInteractable interactable, out Component owner))
            {
                SetTarget(interactable, owner);
            }
            else
            {
                SetTarget(null, null);
            }

            return;
        }

        SetTarget(null, null);
    }

    private static bool TryFindInteractable(Collider hitCollider, out IInteractable interactable, out Component owner)
    {
        MonoBehaviour[] behaviours = hitCollider.GetComponentsInParent<MonoBehaviour>(true);
        for (int i = 0; i < behaviours.Length; i++)
        {
            if (behaviours[i] != null && behaviours[i].isActiveAndEnabled && behaviours[i] is IInteractable candidate)
            {
                interactable = candidate;
                owner = behaviours[i];
                return true;
            }
        }

        interactable = null;
        owner = null;
        return false;
    }

    private void SetTarget(IInteractable target, Component owner)
    {
        if (ReferenceEquals(currentTargetComponent, owner))
        {
            currentTarget = target;
            return;
        }

        currentTarget = target;
        currentTargetComponent = owner;

        if (target is IInteractionPrompt promptSource)
        {
            Debug.Log(promptSource.GetInteractionPrompt(interactionKey.ToString()), this);
        }
    }
}
