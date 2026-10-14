using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int correctCode = 1234;
    [SerializeField] private int enteredCode;

    private bool isSolved;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckCode(enteredCode);
        }
    }

    public bool CheckCode(int code)
    {
        if (code != correctCode)
        {
            Debug.Log("Incorrect puzzle code");
            return false;
        }

        if (isSolved)
        {
            return true;
        }

        isSolved = true;
        Debug.Log("Correct puzzle code");
        Debug.Log("Puzzle solved");
        return true;
    }
}