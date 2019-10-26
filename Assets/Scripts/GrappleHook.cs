using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GrappleHook : MonoBehaviour
{
    [SerializeField]
    private Transform hostTransform;

    private Transform mainCamera;

    private FirstPersonController fpsController;

    private void Start()
    {
        mainCamera = Camera.main.transform;
        fpsController = hostTransform.GetComponent<FirstPersonController>();
    }

    void Update()
    {
        //1. znalezienie powierzchni grapple 

        if (Input.GetButton("Fire2"))
        {
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hit, 15))
            {
                hostTransform.position = Vector3.Lerp(hostTransform.position, hit.point, 0.1f);
            }
        }
    }
}
