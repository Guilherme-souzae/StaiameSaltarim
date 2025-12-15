using UnityEngine;
using System.Collections;

public class CircleGun : BaseGun
{
    public int bulletDensity = 10;
    public float angleOffset = 0f;

    protected override void shoot()
    {
        // Um tiro = gerar o círculo inteiro
        float step = 360f / bulletDensity;

        for (int i = 0; i < bulletDensity; i++)
        {
            float angle = step * i;
            Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle + angleOffset);
            ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, rotation);
        }
    }

    protected override IEnumerator DiscreteShoot()
    {
        // Para CircleGun, discrete é apenas chamar shoot() fireTimes vezes
        float interval = 1f / fireRate;

        for (int i = 0; i < fireTimes; i++)
        {
            shoot(); // produz um círculo inteiro
            yield return new WaitForSeconds(interval);
        }
    }
}
