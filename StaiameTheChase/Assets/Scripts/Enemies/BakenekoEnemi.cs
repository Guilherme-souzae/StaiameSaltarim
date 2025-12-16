using UnityEngine;
using System.Collections;

public class BakenekoEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float fallTime = 1f;
    public float zigzagAmplitude = 10f;

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        yield return new WaitForSeconds(fallTime);
        rb.linearVelocityY = 0f;
        guns[0].tryShoot();
        guns[1].tryShoot();
        yield return new WaitForSeconds(1);
        guns[2].tryShoot();
        if (transform.position.x < 0)
        {
            rb.linearVelocityX = 10f;
        }
        else
        {
            rb.linearVelocityX = -10f;
        }
        while (true)
        {
            rb.linearVelocityY = zigzagAmplitude;
            yield return new WaitForSeconds(0.5f);
            rb.linearVelocityY = -zigzagAmplitude;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
