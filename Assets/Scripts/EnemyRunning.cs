using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunning : MonoBehaviour
{ 

    [SerializeField]
    GameObject player;

    void FixedUpdate()
        {
       
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            transform.Translate(Vector3.forward*Time.deltaTime * 3);

        }

}




