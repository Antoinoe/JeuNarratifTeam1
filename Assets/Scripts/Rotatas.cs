using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatas : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;
    Touch touch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnMouseDown()
    {
        touch = Input.GetTouch(0);
        dragging = true;

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            touch = Input.GetTouch(0);
            float x = touch.deltaPosition.x * rotationSpeed * Time.fixedDeltaTime;
            float y = touch.deltaPosition.y * rotationSpeed * Time.fixedDeltaTime;
            Debug.Log(touch.deltaPosition);

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
    }
}
