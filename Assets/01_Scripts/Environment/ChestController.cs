using UnityEngine;

[DisallowMultipleComponent]
public sealed class ChestController : MonoBehaviour, IInteractable, IInteractionPrompt
{
    [SerializeField] private bool unlocked;
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject keyReward;

    public bool IsUnlocked => unlocked;
    public bool IsOpen => isOpen;

    public void SetKeyReward(GameObject reward)
    {
        keyReward = reward;
        if (keyReward != null && !isOpen)
        {
            keyReward.SetActive(false);
        }
    }

    public string GetInteractionPrompt(string interactionKeyLabel)
    {
        string keyLabel = string.IsNullOrWhiteSpace(interactionKeyLabel) ? "E" : interactionKeyLabel;
        if (isOpen)
        {
            return "Cofre abierto";
        }

        return unlocked ? keyLabel + " - Abrir cofre" : keyLabel + " - Cofre cerrado";
    }

    public void Unlock()
    {
        if (unlocked)
        {
            return;
        }

        unlocked = true;
        Debug.Log("Cofre desbloqueado. Pulsa E frente al cofre.", this);
    }

    public void Interact()
    {
        if (isOpen)
        {
            return;
        }

        if (!unlocked)
        {
            Debug.Log("El cofre está cerrado. Resuelve el código con P.", this);
            return;
        }

        isOpen = true;
        if (keyReward != null)
        {
            keyReward.SetActive(true);
        }

        Debug.Log("Cofre abierto.", this);
    }
}
