using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
