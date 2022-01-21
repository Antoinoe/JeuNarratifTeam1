using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzleFinished;
    [SerializeField] Puzzle[] puzzlePieces;

    private void Start()
    {
        foreach (Puzzle piece in puzzlePieces)
        {
            piece.piecePlaced.AddListener(CheckPieces);
        }
    }

    public void CheckPieces()
    {
        bool puzzleDone = true;
        foreach (Puzzle piece in puzzlePieces)
        {
            if (!piece.inRightPos)
            {
                puzzleDone = false;
                break;
            }
        }

        if (puzzleDone)
        {
            puzzleFinished.SetActive(true);
            GameManager.Instance.NextStage();
            Debug.Log("puzzle finished");
        }
    }

    public void ReturnToHub()
    {
        GameManager.Instance.UnloadSceneAsync("PuzzleMinigame");
    }
}
