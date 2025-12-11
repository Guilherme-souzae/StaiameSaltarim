using UnityEngine;
using System.Collections;

public interface IEnemyAction
{
    public IEnumerator Execute(EnemyController enemy);
}
