using UnityEngine;

[CreateAssetMenu(fileName = "MoveActionSO", menuName = "Scriptable Objects/MoveActionSO")]
public class MovetoActionSO : ScriptableEnemyAction
{
    public Vector2 target;
    public float duration;

    public override IEnemyAction CreateAction() => new MovetoAction
    {
        target = target,
        duration = duration
    };
}
