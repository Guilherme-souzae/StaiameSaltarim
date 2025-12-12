using UnityEngine;
using System.Collections;

public class LineGun : BaseGun
{
    protected override void shoot()
    {
        // Um tiro = um projétil na direção atual
        ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    protected override IEnumerator DiscreteShoot()
    {
        // Rajada simples de fireTimes tiros
        float interval = 1f / fireRate;

        for (int i = 0; i < fireTimes; i++)
        {
            shoot();                   // dispara um projétil
            yield return new WaitForSeconds(interval);
        }
    }
}
