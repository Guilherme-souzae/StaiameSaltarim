using UnityEngine;
using System.Collections;

public class SpiralGun : BaseGun
{
    public float angleStep = 10f;
    public float delay = 0.05f;
    public int shots = 50;

    private bool isShooting = false;

    public override void shoot()
    {
        if (!isShooting)
            StartCoroutine(SpiralRoutine());
    }

    private IEnumerator SpiralRoutine()
    {
        isShooting = true;

        float angle = 0f;

        for (int i = 0; i < shots; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle);
            ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, rotation);
            angle += angleStep;

            yield return new WaitForSeconds(delay);
        }

        isShooting = false;
    }
}
