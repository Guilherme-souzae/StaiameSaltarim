using UnityEngine;
using System.Collections;

public abstract class BaseGun : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Modo contínuo
    public float fireRate = 5f; // tiros por segundo

    // Modo intervalado / rajada
    public int fireTimes = 10;

    public bool isContinuous = false;

    private float nextShootTime = 0f;
    private bool isFiringBurst = false;

    public void tryShoot()
    {
        if (isActiveAndEnabled == false) return;

        if (isContinuous)
            ContinuousShoot();    // Sem corrotinas
        else
            StartDiscreteShoot(); // Com corrotina
    }

    // ---------------------
    //  TIRO CONTÍNUO
    // ---------------------
    protected void ContinuousShoot()
    {
        float interval = 1f / fireRate;

        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + interval;
            shoot(); // dispara 1 tiro
        }
    }

    // ---------------------
    //   TIRO INTERVALADO
    // ---------------------
    private void StartDiscreteShoot()
    {
        // Evita iniciar duas rajadas ao mesmo tempo
        if (!isFiringBurst)
            StartCoroutine(DiscreteShootWrapper());
    }

    private IEnumerator DiscreteShootWrapper()
    {
        isFiringBurst = true;
        yield return StartCoroutine(DiscreteShoot());
        isFiringBurst = false;
    }

    // Cada arma implementa COMO a rajada funciona
    protected abstract IEnumerator DiscreteShoot();

    // Cada arma implementa COMO ela atira 1 projétil
    protected abstract void shoot();
}
