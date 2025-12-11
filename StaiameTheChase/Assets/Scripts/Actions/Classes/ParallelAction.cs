using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ParallelAction : IEnemyAction
{
    public List<IEnemyAction> actions;

    public IEnumerator Execute(EnemyController enemy)
    {
        List<Coroutine> running = new List<Coroutine>();

        foreach (var action in actions)
        {
            running.Add(enemy.StartCoroutine(action.Execute(enemy)));
        }

        foreach (var c in running)
        {
            yield return c;
        }
    }
}
