using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int correctCode = 1234;

    public bool CheckCode(int enteredCode)
    {
        if (enteredCode != correctCode)
        {
            Debug.Log("Incorrect puzzle code");
            return false;
        }

        Debug.Log("Correct puzzle code");
        return true;
    }
}