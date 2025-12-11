using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<ScriptableEnemyAction> actions;

    private void Start()
    {
        StartCoroutine(RunBehavior());
    }

    private IEnumerator RunBehavior()
    {
        foreach (var action in actions)
        {
            yield return action.CreateAction().Execute(this);
        }
    }
}
