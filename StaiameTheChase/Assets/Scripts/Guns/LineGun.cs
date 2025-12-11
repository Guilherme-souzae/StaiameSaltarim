using UnityEngine;

public class LineGun : BaseGun
{
    public override void shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
