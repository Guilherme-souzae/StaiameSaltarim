using UnityEngine;
using System.Collections;

public class DoubleSpiralGun : BaseGun
{
    public bool clockwise = true;
    public float angleStep = 10f;
    public float angleOffset = 0f;
    public float delay = 0.05f;
    public int shotPairs = 50;

    private int Shots => shotPairs * 2;

    protected override void shoot()
    {
        // Nada acontece feijoada
    }

    protected override IEnumerator DiscreteShoot()
    {
        float angle = angleOffset;

        for (int i = 0; i < Shots; i++)
        {
            // Disparo duplo em espiral
            Quaternion rotation =
                clockwise
                ? Quaternion.Euler(0, 0, transform.eulerAngles.z + angle)
                : Quaternion.Euler(0, 0, transform.eulerAngles.z - angle);

            ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, rotation);
            ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, rotation * Quaternion.Euler(0, 0, 180f));

            angle += angleStep;

            // delay entre cada par de tiros
            yield return new WaitForSeconds(delay);
        }
    }
}
