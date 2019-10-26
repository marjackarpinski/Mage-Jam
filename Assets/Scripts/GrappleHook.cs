using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private GameObject pointX;

    RaycastHit hit;
    Vector3 rayedElementPoint;
    bool doGrapple = false;
    bool unClicked = false;

    void Update()
    {
        //1. znalezienie powierzchni grapple 

        if (Input.GetButtonDown("Fire2"))
        {
            unClicked = !unClicked;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 15) && !doGrapple)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                rayedElementPoint = hit.point;
                doGrapple = true;
                pointX.SetActive(true);
                
                pointX.transform.position = rayedElementPoint;
            } else if (doGrapple && !unClicked)
            {
                    doGrapple = false;
                    pointX.SetActive(false);

            }

        }

        //2. grapple follow

        if(doGrapple)
        {

            Vector3 direction = rayedElementPoint- parent.transform.position;
            Debug.Log(direction);
            parent.GetComponent<Rigidbody>().AddForce(direction * 202);
        }
        
    }
}
