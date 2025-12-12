using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeArsenalActionSO", menuName = "Scriptable Objects/ChangeArsenalActionSO")]
public class ChangeArsenalActionSO : ScriptableEnemyAction
{
    // EXEMPLO: lista indicando quais armas ativar
    public List<bool> actives;

    public override IEnemyAction CreateAction()
    {
        return new ChangeArsenalAction
        {
            actives = new List<bool>(actives)
        };
    }
}
