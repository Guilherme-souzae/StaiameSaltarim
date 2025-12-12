using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ChangeArsenalAction : IEnemyAction
{
    // Lista que indica se cada arma deve estar ativa ou não
    public List<bool> actives = new List<bool>();

    public IEnumerator Execute(EnemyController enemy)
    {
        // Pega TODOS os BaseGun nos filhos do inimigo
        BaseGun[] guns = enemy.GetComponentsInChildren<BaseGun>(true);

        // Garante que a lista actives tem o mesmo tamanho das armas
        int len = Mathf.Min(guns.Length, actives.Count);

        for (int i = 0; i < len; i++)
        {
            guns[i].gameObject.SetActive(actives[i]);
        }

        // Encerramos imediatamente (fire-and-forget)
        yield break;
    }
}
