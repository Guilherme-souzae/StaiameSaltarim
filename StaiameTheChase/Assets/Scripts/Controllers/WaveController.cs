using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<float> spawnIntervals = new List<float>();
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<Vector2> spawnPositions = new List<Vector2>();

    private void Start()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            yield return new WaitForSeconds(spawnIntervals[i]);
            Instantiate(enemyPrefabs[i], spawnPositions[i], Quaternion.identity);
        }
    }
}