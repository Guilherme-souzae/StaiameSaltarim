using UnityEngine;
using System.Collections;

public class NekomataEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float fallTime = 1f;
    public float zigzagAmplitude = 10f;

    private int zigzagSignal;

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        yield return new WaitForSeconds(fallTime);
        rb.linearVelocityY = 0f;
        guns[0].tryShoot();
        guns[1].tryShoot();
        yield return new WaitForSeconds(2);
        rb.linearVelocityY = - 3 * fallSpeed;

        zigzagSignal = (Random.value > 0.5f) ? 1 : -1;
        rb.linearVelocityX = -zigzagAmplitude * zigzagSignal;
        yield return new WaitForSeconds(0.25f);
        while (true)
        {
            rb.linearVelocityX = zigzagAmplitude * zigzagSignal;
            yield return new WaitForSeconds(0.5f);
            rb.linearVelocityX = -zigzagAmplitude * zigzagSignal;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
