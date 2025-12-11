using UnityEngine;

public class CircleGun : BaseGun
{
    public int bulletDensity = 10;
    public override void shoot()
    {
        float step = 360f / bulletDensity;

        for (int i = 0; i < bulletDensity; i++)
        {
            float angle = step * i;
            Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle);
            ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, rotation);
        }
    }
}
