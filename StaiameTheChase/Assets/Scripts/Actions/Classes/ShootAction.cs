using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShootAction : IEnemyAction
{
    public IEnumerator Execute(EnemyController enemy)
    {
        // Pega TODAS as armas no inimigo
        BaseGun[] guns = enemy.GetComponentsInChildren<BaseGun>();

        // Fire-and-forget: simplesmente manda cada arma atirar
        foreach (BaseGun gun in guns)
            gun.tryShoot();

        // Encerramos imediatamente
        yield break;
    }
}
