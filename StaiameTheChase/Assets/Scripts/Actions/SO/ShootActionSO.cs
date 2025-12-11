using UnityEngine;

[CreateAssetMenu(fileName = "ShootActionSO", menuName = "Scriptable Objects/ShootActionSO")]
public class ShootActionSO : ScriptableEnemyAction
{
    public int times = 1;
    public int interval = 1;

    public override IEnemyAction CreateAction()
    {
        return new ShootAction
        {
            times = times,
            interval = interval
        };
    }
}
