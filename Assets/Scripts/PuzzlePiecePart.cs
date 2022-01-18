using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePart : MonoBehaviour
{
    public Puzzle puzzle;
    public int id;
    public Vector3 offset;
    public Transform connectedPiece;
    public bool isConnect = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            Debug.Log("piece found");
            PuzzlePiecePart piece = collision.gameObject.GetComponent<PuzzlePiecePart>();
            if(id == piece.id && !isConnect)
            {
                Debug.Log("same id");
                isConnect = true;
                offset = piece.transform.position - puzzle.transform.position;
                connectedPiece = piece.puzzle.gameObject.transform;
            }
        }
    }
}
