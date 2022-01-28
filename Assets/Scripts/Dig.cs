using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject maskPrefab;
    private Touch theTouch;
    public bool canDig;
    Ray ray;

    private void Update()
    {
        if (Input.touchCount != 0)
        {
            theTouch = Input.GetTouch(0);

            
            if (theTouch.phase == TouchPhase.Began)
            {
                canDig = true;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.gameObject.transform.position, Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10), 20, LayerMask.GetMask("Artifact"));
                if (hit.collider != null)
                {
                    hit.collider.gameObject.SetActive(false);
                    DigManager.Instance.ArtifactFound();
                }

            }
            if(theTouch.phase == TouchPhase.Ended)
            {
                canDig = false;
            }
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10);
        if (canDig && !Physics2D.Raycast(pos - new Vector3(0, 0, 1), pos, 20, LayerMask.GetMask("Mask")))
        {
            Instantiate(maskPrefab, Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10), Quaternion.identity, transform);

        }

    }

    private void OnDrawGizmos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(theTouch.position) + new Vector3(0, 0, 10);
        Gizmos.color = Physics2D.Raycast(pos - new Vector3(0,0 ,1), pos, 20, LayerMask.GetMask("Mask")) ? Color.red : Color.green;
        Gizmos.DrawLine(pos - new Vector3(0, 0, 1), pos);
    }
}
