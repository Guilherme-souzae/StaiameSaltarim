using UnityEngine;

[CreateAssetMenu(fileName = "RelactiveMovetoActionSO", menuName = "Scriptable Objects/RelactiveMovetoActionSO")]
public class RelactiveMovetoActionSO : ScriptableEnemyAction
{
    public Vector2 offset;
    public float duration;

    public override IEnemyAction CreateAction()
    {
        return new RelativeMovetoAction
        {
            offset = offset,
            duration = duration
        };
    }
}
