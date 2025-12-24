using System.Collections;
using UnityEngine;

public class HomingProjectile : BaseProjectile
{
    public bool isEnemy = false;
    public float startHomingDelay = 0.5f;
    public float homingTime = 10f;
    public float speed = 10f;
    public float turnSpeed = 5f;
    public float colorCycleSpeed = 1f;

    private bool isHoming = false;
    private Transform target;

    private void OnEnable()
    {
        isHoming = false;
        target = null;
        StartCoroutine(Homing());
    }

    private void FixedUpdate()
    {
        if (!isHoming)
        {
            rb.linearVelocity = transform.up * speed;
            return;
        }

        if (target == null)
        {
            target = FindClosestTarget(isEnemy ? "Player" : "Enemy");
            if (target == null)
            {
                rb.linearVelocity = transform.up * speed;
                return;
            }
        }

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;

        Vector2 newDir = Vector2.Lerp(
            rb.linearVelocity.normalized,
            dir,
            turnSpeed * Time.fixedDeltaTime
        );

        rb.linearVelocity = newDir * speed;

        // opcional: rotaciona sprite
        float angle = Mathf.Atan2(newDir.y, newDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private IEnumerator Homing()
    {
        yield return new WaitForSeconds(startHomingDelay);
        isHoming = true;
        yield return new WaitForSeconds(homingTime);
        isHoming = false;
    }

    private Transform FindClosestTarget(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        Transform closest = null;
        float minDist = Mathf.Infinity;
        Vector2 pos = rb.position;

        foreach (var t in targets)
        {
            float dist = Vector2.SqrMagnitude((Vector2)t.transform.position - pos);
            if (dist < minDist)
            {
                minDist = dist;
                closest = t.transform;
            }
        }

        return closest;
    }
}
