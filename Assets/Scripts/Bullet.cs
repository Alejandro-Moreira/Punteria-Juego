using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    public GameObject hitEffect;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Mueve la bala recto hacia adelante
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bala tocó: " + other.name);

        // Solo destruye enemigos
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bala impactó un enemigo: " + other.name);
            Destroy(other.gameObject); // Destruye el enemigo
            Destroy(gameObject);       // Destruye la bala
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
