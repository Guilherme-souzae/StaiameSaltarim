using System.Collections;
using UnityEngine;

public class RotatingBombProjectile : BaseProjectile
{
    public GameObject explosionPrefab;
    public float speed = 3f;
    public int explosionQuantity = 10;
    public float rotationSpeed = 10f;
    public float explosionDelay = 1f;

    private float clockWise = 1f;

    private void OnEnable()
    {
        rb.linearVelocity = transform.up * speed;
        clockWise = (Random.value > 0.5f) ? 1f : -1f;
        transform.rotation = Quaternion.identity;
        StartCoroutine(Behavior());
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
