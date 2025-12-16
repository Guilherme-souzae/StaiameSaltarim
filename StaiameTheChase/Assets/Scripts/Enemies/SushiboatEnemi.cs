using UnityEngine;
using System.Collections;

public class SushiboatEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float fallTime = 1f;

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        yield return new WaitForSeconds(fallTime);
        rb.linearVelocityY = 0f;
        foreach (var gun in guns)
        {
            gun.tryShoot();
        }
        yield return new WaitForSeconds(1);
        rb.linearVelocityY = -fallSpeed * 10;
    }
}
