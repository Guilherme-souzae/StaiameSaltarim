using UnityEngine;

public class CircleGun : BaseGun
{
    public int bulletDensity = 10;
    private const float spreadAngle = 360f;
    public override void shoot()
    {
        for (int i = 0; i < bulletDensity; i++)
        {
            float angle = -spreadAngle / 2 + (spreadAngle / (bulletDensity - 1)) * i;
            Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle);
            Instantiate(bulletPrefab, transform.position, rotation);
        }
    }
}
