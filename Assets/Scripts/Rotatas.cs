using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatas : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;
    Touch touch;
    [SerializeField] List<DialogueTrigger> dialogue = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (dialogue[0] != null)
            dialogue[0].TriggerDialogue();
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
            

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
    }

    public void BackToHub(string sceneToUnload)
    {

        //GameManager.Instance.NextStage();
        GameManager.Instance.UnloadSceneAsync(sceneToUnload);
    }
}
