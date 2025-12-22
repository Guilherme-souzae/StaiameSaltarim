using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySpawnData> spawns = new List<EnemySpawnData>();

    private void Start()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        for (int i = 0; i < spawns.Count; i++)
        {
            yield return new WaitForSeconds(spawns[i].spawnDelay);
            Instantiate(spawns[i].enemyPrefab, spawns[i].position, Quaternion.identity);
        }
    }
}