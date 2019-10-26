using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportControl : MonoBehaviour
{
    [SerializeField]
    private GameObject teleport;

    [SerializeField]
    private GameObject parent;

    RaycastHit hit;
    Vector3 rayedElementLocation;
    bool doTeleport = false;
    // on rpm show teleport and after release teleport there

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            doTeleport = true;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.point);
                rayedElementLocation = hit.point;

                teleport.SetActive(true);
                teleport.transform.position = rayedElementLocation;
                Debug.Log($"rotation {teleport.transform.rotation}, normal {hit.normal}");
                teleport.transform.LookAt(hit.point + hit.normal);
                teleport.transform.position += teleport.transform.forward * 0.05f;
                Debug.Log($"rotation {teleport.transform.rotation}");
            }   
            else
            {
                Debug.Log("HWDP");
            }
        }else if(doTeleport)
        {
            doTeleport = false;
            parent.transform.position = rayedElementLocation;    
            Debug.Log("BOM");
            teleport.SetActive(false);

        }

    }
}
    