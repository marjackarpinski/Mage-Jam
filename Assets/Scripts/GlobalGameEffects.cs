using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameEffects : MonoBehaviour
{

    public static Vector3 defaultGravity;

    [SerializeField]
    private Transform envirounment;
    private float minRotationOffset = 1;
    private bool isRotating = false;
    private Vector3 targetRotation = Vector3.zero;

    private void Start()
    {
        if (defaultGravity != null)
            defaultGravity = Physics.gravity;
    }

    public void SetGravityLevel(float defaultGravityPercentage)
    {
        Physics.gravity = defaultGravity * defaultGravityPercentage;
    }

    public void ChangeTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void RestoreDefaultGravity()
    {
        Physics.gravity = defaultGravity;
    }

    public void RotateWorld(Vector3 rotationValue)
    {
        Debug.Log("Starting Rotation");
        isRotating = true;
        targetRotation = envirounment.rotation.eulerAngles + rotationValue;
    }

    private void Update()
    {
        if(isRotating)
        {
            Debug.Log($"IsRotating, enviounmentRotation {envirounment.rotation.eulerAngles}, targetRotation {targetRotation}");
            envirounment.rotation = Quaternion.Euler(Vector3.Lerp(envirounment.rotation.eulerAngles, targetRotation, 0.05f));
            if((envirounment.rotation.eulerAngles - targetRotation).magnitude < minRotationOffset)
            {
                envirounment.rotation = Quaternion.Euler(targetRotation);
                isRotating = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            RotateWorld(new Vector3(0, 0, 90));
        }

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    ChangeTimeScale(1);
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    SetGravityLevel(0);
        //}
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    SetGravityLevel(0.5f);
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    RestoreDefaultGravity();
        //}
    }


}
