using UnityEngine;

public class LineProjectile : BaseProjectile
{
    public float speed = 10f;

    void OnEnable()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
