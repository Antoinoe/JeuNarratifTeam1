using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount != 0)
        {
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collided");
        if (other.CompareTag("Mask"))
        {
            Debug.Log("gg t'as trouver :)))");
        }
    }
}
