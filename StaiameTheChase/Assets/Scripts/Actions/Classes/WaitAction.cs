using UnityEngine;
using System.Collections;

public class WaitAction : IEnemyAction
{
    public float waitTime;
    public IEnumerator Execute(EnemyController enemy)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
