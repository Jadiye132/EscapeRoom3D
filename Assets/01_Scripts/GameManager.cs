using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int initializationCount;

    private void Start()
    {
<<<<<<< HEAD
Initialize(); // CASO 16 B
=======
Initialize(); // CASO 16 A
>>>>>>> caso16-a-practica
    }

    public void Initialize()
    {
        initializationCount++;

        if (initializationCount > 1)
        {
            Debug.LogError("GameManager se inicializo mas de una vez.", this);
            return;
        }

        Debug.Log("GameManager inicializado correctamente.", this);
    }
}