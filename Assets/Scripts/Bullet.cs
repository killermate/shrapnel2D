using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;  // or transform.up, depending on your sprite orientation
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
    }
}