using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyWaveData> spawns = new List<EnemyWaveData>();
    public bool loop = true;

    private int index = 0;

    private void Start()
    {
        if (spawns.Count > 0)
            StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnSequence());
            index++;

            if (index >= spawns.Count)
            {
                if (loop)
                {
                    index = 0;
                }
                else
                {
                    yield break;
                }
            }
        }
    }

    private IEnumerator SpawnSequence()
    {
        EnemyWaveData currWave = spawns[index];
        yield return new WaitForSeconds(currWave.startDelay);
        foreach (EnemySpawnData spawnData in currWave.spawns)
        {
            StartCoroutine(SpawnEnemy(spawnData));
        }
    }

    private IEnumerator SpawnEnemy(EnemySpawnData spawnData)
    {
        yield return new WaitForSeconds(spawnData.spawnDelay);
        Instantiate(spawnData.enemyPrefab, spawnData.position, Quaternion.identity);
    }
}