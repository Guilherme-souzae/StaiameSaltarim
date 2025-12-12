using UnityEngine;

[CreateAssetMenu(fileName = "ShootActionSO", menuName = "Scriptable Objects/ShootActionSO")]
public class ShootActionSO : ScriptableEnemyAction
{
    public override IEnemyAction CreateAction()
    {
        return new ShootAction { };
    }
}
