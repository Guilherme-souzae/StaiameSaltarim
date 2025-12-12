using UnityEngine;
using System.Collections;

public class SpreadGun : BaseGun
{
    public int bulletCount = 5;
    public float spreadAngle = 30f;

    protected override void shoot()
    {
        // Um tiro = um spread completo
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = -spreadAngle / 2f
                + (spreadAngle / (bulletCount - 1)) * i;

            Quaternion rotation = Quaternion.Euler(
                0, 0, transform.eulerAngles.z + angle
            );

            ObjectPool.Instance.Instantiate(
                bulletPrefab,
                transform.position,
                rotation
            );
        }
    }

    protected override IEnumerator DiscreteShoot()
    {
        // Dispara fireTimes spreads com intervalo baseado no fireRate
        float interval = 1f / fireRate;

        for (int i = 0; i < fireTimes; i++)
        {
            shoot(); // spread completo
            yield return new WaitForSeconds(interval);
        }
    }
}
