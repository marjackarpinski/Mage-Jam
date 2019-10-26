using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameEffects : MonoBehaviour
{

    public static Vector3 defaultGravity;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeTimeScale(0.5f);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeTimeScale(1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SetGravityLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetGravityLevel(0.5f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RestoreDefaultGravity();
        }
    }


}
