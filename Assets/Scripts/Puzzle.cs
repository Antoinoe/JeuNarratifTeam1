using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform connectPiece;
    public Vector3 pieceOffset;
    [SerializeField] PuzzlePiecePart[] points;

    bool followFinger;
    Vector3 fingerOffset;
    Touch theTouch;
    [SerializeField] Collider2D col;

    private void Update()
    {

        if (followFinger)
        {
            theTouch = Input.GetTouch(0);
            transform.position = Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10) /*+fingerOffset*/;
            foreach (PuzzlePiecePart item in points)
            {
                if (item.isConnect)
                {
                    item.connectedPiece.transform.position = transform.position + item.offset;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        followFinger = true;
        //fingerOffset = transform.position - (Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10));

    }

    private void OnMouseUp()
    {
        followFinger = false;
    }


}
