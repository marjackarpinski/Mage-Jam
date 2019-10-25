using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage = 5;

    [SerializeField]
    private float bulletSpeed;

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
        }
        Destroy(gameObject);
    }
}
