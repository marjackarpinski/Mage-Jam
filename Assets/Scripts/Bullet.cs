using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage = 5;

    [SerializeField]
    private float bulletSpeed;

    private float bulletForce = 20;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damagableObject = other.transform.GetComponent<IDamagable>();
        if (damagableObject != null)
        {
            damagableObject.TakeDamage(bulletDamage);
            other.attachedRigidbody.AddForce(transform.forward * bulletForce);
        }
        Destroy(gameObject);
    }
}
