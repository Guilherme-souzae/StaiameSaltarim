using UnityEngine;
using System.Collections;

public class KunekuneEnemi : EnemyController
{
    public float fallSpeed = 5f;
    public float amplitude = 10f;
    public float waveFrequency = 1f;

    private int waveSignal;
    private float timeBuffer = 0f;

    private void FixedUpdate()
    {
        timeBuffer += Time.fixedDeltaTime;
        rb.linearVelocityX = amplitude * waveFrequency * Mathf.Cos(waveFrequency * timeBuffer);
    }

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        guns[0].tryShoot();
        yield break;
    }
}
