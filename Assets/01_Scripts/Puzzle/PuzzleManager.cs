using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private bool isSolved;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SolvePuzzle();
        }
    }

    public void SolvePuzzle()
    {
        if (isSolved)
        {
            return;
        }

        isSolved = true;
        Debug.Log("Puzzle solved");
    }
}
