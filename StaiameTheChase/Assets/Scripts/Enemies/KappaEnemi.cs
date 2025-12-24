using UnityEngine;
using System.Collections;

public class KappaEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float fallTime = 1f;

    private bool isAiming = false;

    private Transform player;
    public float aimSpeed = 5f;

    private void FixedUpdate()
    {
        if (!isAiming) return;

        if (player == null)
            player = GameObject.FindWithTag("Player")?.transform;

        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;

        float smoothAngle = Mathf.LerpAngle(
            rb.rotation,
            angle,
            aimSpeed * Time.fixedDeltaTime
        );

        rb.rotation = smoothAngle;
    }


    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        yield return new WaitForSeconds(fallTime);
        isAiming = true;
        rb.linearVelocityY = 0f;
        guns[0].tryShoot();
        yield return new WaitForSeconds(2.5f);
        guns[1].tryShoot();
        isAiming = false;
        yield return new WaitForSeconds(0.1f);
        guns[2].tryShoot();
        Destroy(gameObject);
    }
}
