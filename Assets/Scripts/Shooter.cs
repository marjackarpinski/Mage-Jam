using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private LayerMask raycastingLayer;

    [SerializeField]
    private float timeBetweenBullets = 0.15f;
    private float lastBulletTime;

    [SerializeField]
    private Transform bulletStartingPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private ParticleSystem gunBurst;

    private void Start()
    {
        lastBulletTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && lastBulletTime > timeBetweenBullets)
        {

            //// Bit shift the index of the layer "Player" to get a bit mask
            //LayerMask layerMask = LayerMask.GetMask("Player");

            //// This would cast rays only against colliders in layer 8.
            //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;


            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity, raycastingLayer))
            {
                Debug.Log(hit.transform.tag);
                var bulletObject = Instantiate(bulletPrefab, bulletStartingPoint.position, Quaternion.identity);
                if (hit.transform.CompareTag("Player"))
                {
                    bulletObject.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);
                }
                else
                {
                    bulletObject.transform.LookAt(hit.point);
                }


                gunBurst.Play();
            }
            lastBulletTime = 0;
        }
        lastBulletTime += Time.deltaTime;
    }
}
