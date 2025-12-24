using System.Collections;
using UnityEngine;

public class SuperPizzaProjectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 20f;
    public int explosionQuantity = 10;
    public float rotationSpeed = 10f;
    public float explosionDelay = 1f;

    private float clockWise = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        clockWise = (Random.value > 0.5f) ? 1f : -1f;
        transform.rotation = Quaternion.identity;
        StartCoroutine(Behavior());
        rb.linearVelocityY = speed;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 10f * clockWise);
    }

    private IEnumerator Behavior()
    {
        yield return new WaitForSeconds(explosionDelay);
        for (int i = 0; i < explosionQuantity; i++)
        {
            float angle = (360f / explosionQuantity) * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            ObjectPool.Instance.Instantiate(explosionPrefab, transform.position, rotation);
        }
        ObjectPool.Instance.Recycle(gameObject);
    }
}
