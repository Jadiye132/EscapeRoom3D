using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int correctCode = 1234;
    [SerializeField] private int enteredCode;
    [SerializeField] private KeyCode solveKey = KeyCode.P;

    private bool isSolved;

    private void Update()
    {
        if (Input.GetKeyDown(solveKey))
        {
            CheckCode(enteredCode);
        }
    }

    public bool CheckCode(int code)
    {
        if (isSolved)
        {
            return true;
        }

        if (code != correctCode)
        {
            Debug.Log("Incorrect puzzle code");
            return false;
        }

        isSolved = true;
        Debug.Log("Correct puzzle code");
        Debug.Log("Puzzle solved");
        return true;
    }
}