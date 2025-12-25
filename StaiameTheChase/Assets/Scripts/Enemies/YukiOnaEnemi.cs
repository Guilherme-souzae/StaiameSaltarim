using UnityEngine;
using System.Collections;

public class YukiOnaEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float fallTime = 1f;
    public float shootDelay = 3f;

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        yield return new WaitForSeconds(fallTime);
        rb.linearVelocityY = 0f;
        guns[0].tryShoot();
        guns[1].tryShoot();
        yield return new WaitForSeconds(shootDelay);
        rb.linearVelocityY = fallSpeed * 2;
    }
}
