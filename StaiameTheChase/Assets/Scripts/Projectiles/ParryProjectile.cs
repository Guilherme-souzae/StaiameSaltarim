using System.Collections;
using UnityEngine;

public class ParryProjectile : BaseProjectile
{
    public float speed = 10f;
    public float maxBounceAngle = 75f;

    private bool isEnemy = false;

    private void OnEnable()
    {
        isEnemy = true;
        rb.linearVelocity = transform.up * speed;
    }

    public void Parry(float normalizedHit)
    {
        Debug.Log("Projétil Parried!");

        isEnemy = !isEnemy;

        normalizedHit = Mathf.Clamp(normalizedHit, -1f, 1f);

        float angle = normalizedHit * maxBounceAngle;

        Vector2 direction = (isEnemy) ? Quaternion.Euler(0, 0, angle) * Vector2.up : Quaternion.Euler(0, 0, angle) * Vector2.down;

        rb.linearVelocity = direction.normalized * speed;
    }

    protected void OnBecameInvisible()
    {
        ObjectPool.Instance.Recycle(gameObject);
        GameObject boss = GameObject.FindWithTag("Boss");
        boss.GetComponent<YamuraiEnemi>().RestartPingPong();
    }
}
