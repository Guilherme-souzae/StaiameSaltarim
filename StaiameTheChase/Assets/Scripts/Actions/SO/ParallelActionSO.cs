using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParallelActionSO", menuName = "Scriptable Objects/ParallelActionSO")]
public class ParallelActionSO : ScriptableEnemyAction
{
    public List<ScriptableEnemyAction> actionAssets;

    public override IEnemyAction CreateAction()
    {
        var parallel = new ParallelAction
        {
            actions = new List<IEnemyAction>()
        };

        foreach (var asset in actionAssets)
        {
            parallel.actions.Add(asset.CreateAction());
        }

        return parallel;
    }
}
