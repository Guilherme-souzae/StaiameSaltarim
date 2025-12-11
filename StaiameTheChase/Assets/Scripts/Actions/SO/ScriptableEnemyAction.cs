using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ScriptableEnemyAction", menuName = "Scriptable Objects/ScriptableEnemyAction")]
public abstract class ScriptableEnemyAction : ScriptableObject
{
    public abstract IEnemyAction CreateAction();
}
