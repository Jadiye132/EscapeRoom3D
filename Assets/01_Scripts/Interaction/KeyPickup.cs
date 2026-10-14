using UnityEngine;

[DisallowMultipleComponent]
public sealed class KeyPickup : MonoBehaviour, IInteractable, IInteractionPrompt
{
    [SerializeField] private GameManager gameManager;
    private bool collected;

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    public string GetInteractionPrompt(string interactionKeyLabel)
    {
        string keyLabel = string.IsNullOrWhiteSpace(interactionKeyLabel) ? "E" : interactionKeyLabel;
        return collected ? "Llave recogida" : keyLabel + " - Recoger llave";
    }

    public void Interact()
    {
        if (collected)
        {
            return;
        }

        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }

        if (gameManager == null || !gameManager.CollectKey())
        {
            return;
        }

        collected = true;
        gameObject.SetActive(false);
    }
}
