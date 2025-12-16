using UnityEngine;

public class WaveProjectile : BaseProjectile
{
    public float vertical_speed = 5f;
    public float frequency = 2f;
    public float amplitude = 0.5f;

    private float timeBuffer = 0f;

    void OnEnable()
    {
        rb.linearVelocity = transform.up * vertical_speed;
    }

    private void FixedUpdate()
    {
        timeBuffer += Time.fixedDeltaTime;
        rb.linearVelocityX = amplitude * frequency * Mathf.Cos(frequency * timeBuffer);
    }
}
