using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenBullets = 0.15f;
    private float lastBulletTime;

    [SerializeField]
    private Transform bulletStartingPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    private void Start()
    {
        lastBulletTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && lastBulletTime > timeBetweenBullets)
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
            {
                var bulletObject = Instantiate(bulletPrefab, bulletStartingPoint.position, Quaternion.identity);
                bulletObject.transform.LookAt(hit.point);
            }
            lastBulletTime = 0;
        }
        lastBulletTime += Time.deltaTime;
    }
}
