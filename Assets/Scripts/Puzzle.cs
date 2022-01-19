using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    bool followFinger;
    Vector3 fingerOffset;
    Touch theTouch;
    public Vector3 snapPosition;
    public Vector3 originalPos;

    Vector3 originalScale;
    public bool hasPos = false;
    public bool inRightPos = false;
    public UnityEvent piecePlaced;

    private void Start()
    {
        originalPos = transform.position;
        snapPosition = originalPos;

        originalScale = transform.localScale;
    }

    private void Update()
    {

        if (followFinger)
        {
            theTouch = Input.GetTouch(0);
            transform.position = Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10) +fingerOffset;

        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1, 1, 1);
        followFinger = true;
        theTouch = Input.GetTouch(0);
        fingerOffset = transform.position - (Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10));
    }

    private void OnMouseUp()
    {
        followFinger = false;
        transform.position = snapPosition;
        transform.localScale = hasPos ? new Vector3(1, 1, 1) : originalScale;
        if (hasPos && inRightPos)
        {
            piecePlaced.Invoke();
            Debug.Log("event");
        }

    }
}
