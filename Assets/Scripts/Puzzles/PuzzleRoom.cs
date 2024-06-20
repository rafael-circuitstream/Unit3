using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom : MonoBehaviour
{
    private IPuzzlePiece[] allPieces;
    [SerializeField] private bool isPuzzleCompleted;
    private PuzzleController puzzleController;

    public UnityEvent OnPuzzleStart;
    public UnityEvent OnPuzzleFinish;

    public void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        allPieces = GetComponentsInChildren<IPuzzlePiece>();
    }

    public void CheckRoomStatus()//Should run EVERY TIME a piece gets updated (PressurePlate OnActive())
    {
        isPuzzleCompleted = true;
        foreach (IPuzzlePiece piece in allPieces)
        {
            if (!piece.IsCorrect) isPuzzleCompleted = false;
        }

        if(isPuzzleCompleted)
        {
            Debug.Log("ALL REQUIREMENTS MET");
        }
    }

    public void PuzzleEnter()
    {
        OnPuzzleStart?.Invoke();
        Debug.Log("Player Entered the Room");   
    }

    public void PuzzleExit()
    {
        OnPuzzleFinish?.Invoke();
        Debug.Log("Player Exited the Room");
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }

    
}
