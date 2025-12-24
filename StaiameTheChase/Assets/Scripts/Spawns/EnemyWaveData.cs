using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveData", menuName = "Scriptable Objects/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    public float startDelay;
    public EnemySpawnData[] spawns;
}
