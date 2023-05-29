using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxDistance = 100f; // Maximum distance the bullet can travel

    private float initialDistance;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialDistance = 0f;
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        if (distance >= maxDistance || initialDistance >= maxDistance)
        {
            DestroyBullet();
        }

        initialDistance += rb.velocity.magnitude * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        // Play any desired particle effects, sounds, or other actions before destroying the bullet
        Destroy(gameObject);
    }
}
