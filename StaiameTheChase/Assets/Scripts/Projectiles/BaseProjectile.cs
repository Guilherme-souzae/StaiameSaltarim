using UnityEngine;

public class BaseProjectile : MonoBehaviour
{

    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void OnBecameInvisible()
    {
        ObjectPool.Instance.Recycle(gameObject);
    }
}
