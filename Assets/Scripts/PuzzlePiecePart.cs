using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePart : MonoBehaviour
{
    [SerializeField] Puzzle puzzle;
    [SerializeField] GameObject rightPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            puzzle.snapPosition = collision.transform.position;
            puzzle.hasPos = true;
            if (collision.gameObject == rightPos)
                puzzle.inRightPos = true;
            else
                puzzle.inRightPos = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            puzzle.hasPos = false;
            puzzle.snapPosition = puzzle.originalPos;
            puzzle.inRightPos = false;
        }
    }
}
