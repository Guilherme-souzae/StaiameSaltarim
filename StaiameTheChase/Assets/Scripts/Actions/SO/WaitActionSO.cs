using UnityEngine;

[CreateAssetMenu(fileName = "WaitActionSO", menuName = "Scriptable Objects/WaitActionSO")]
public class WaitActionSO : ScriptableEnemyAction
{
    public float waitTime;

    public override IEnemyAction CreateAction() => new WaitAction
    {
        waitTime = waitTime
    };
}
