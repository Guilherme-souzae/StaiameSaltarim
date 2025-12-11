using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShootAction : IEnemyAction
{
    public int times = 1;
    public float interval = 0f;

    public IEnumerator Execute(EnemyController enemy)
    {
        BaseGun gun = enemy.GetComponentInChildren<BaseGun>();

        if (gun == null)
        {
            yield break;
        }

        for (int i = 0; i < times; i++)
        {
            gun.shoot();

            if (interval > 0)
                yield return new WaitForSeconds(interval);
        }
    }
}
