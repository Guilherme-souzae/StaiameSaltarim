using UnityEngine;

public class SpreadGun : BaseGun
{
    public int bulletCount = 5;
    public float spreadAngle = 30f;
    public override void shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = -spreadAngle / 2 + (spreadAngle / (bulletCount - 1)) * i;
            Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle);
            Instantiate(bulletPrefab, transform.position, rotation);
        }
    }
}
