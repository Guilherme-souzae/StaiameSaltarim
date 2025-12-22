using UnityEngine;
using System.Collections;

public class RotateGun : BaseGun
{
    public float rotationSpeed = 5f;
    protected override void shoot()
    {
        // Um tiro = um projétil na direção atual
        ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, transform.rotation);
        transform.Rotate(0f, 0f, rotationSpeed);
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
