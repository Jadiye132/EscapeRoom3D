using UnityEngine;

[DisallowMultipleComponent]
public sealed class GameManager : MonoBehaviour, IKeyProvider
{
    [SerializeField] private bool hasKey;
    [SerializeField] private int initializationCalls;

    private bool initialized;

    public bool HasKey => hasKey;
    public int InitializationCalls => initializationCalls;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        initializationCalls++;

        if (initialized)
        {
            Debug.LogError("GameManager.Initialize se ejecutó más de una vez. Revisa la resolución del merge.", this);
            return;
        }

        initialized = true;
        hasKey = false;
        Debug.Log("GameManager inicializado.", this);
    }

    public bool CollectKey()
    {
        if (hasKey)
        {
            return false;
        }

        hasKey = true;
        Debug.Log("Llave obtenida.", this);
        return true;
    }
}
