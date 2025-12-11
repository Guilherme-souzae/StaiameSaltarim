using UnityEngine;

public class LineGun : BaseGun
{
    public override void shoot()
    {
        ObjectPool.Instance.Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
