using UnityEngine;

public class Gem : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    public float magnetForce = 15f;

    private Transform player;
    private bool isMagnetized = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float hue = Random.Range(0f, 1f);
        Color gemColor = Color.HSVToRGB(hue, 1f, 1f);
        spriteRenderer.color = gemColor;

        rb.linearVelocityY = -5;
    }

    private void FixedUpdate()
    {
        if (!isMagnetized || player == null) return;

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.linearVelocity = dir * magnetForce;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PointsManager.Instance.Points++;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Magnet"))
        {
            player = collision.transform.root;
            isMagnetized = true;
        }
    }
}
