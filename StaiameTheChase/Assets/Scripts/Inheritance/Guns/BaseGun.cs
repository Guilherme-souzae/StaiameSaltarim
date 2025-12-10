using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 5f;

    private float nextShootTime;

    public float tryShoot()
    {
        if (Time.time < nextShootTime)
            return 0f;
        nextShootTime = Time.time + 1f / fireRate;
        shoot();
        return 1f / fireRate;
    }

    protected abstract void shoot();
}
