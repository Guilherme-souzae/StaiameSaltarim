using UnityEngine;

public class LineGun : BaseGun
{
    protected override void shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
