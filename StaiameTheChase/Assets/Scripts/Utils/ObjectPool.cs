using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public List<GameObject> prefabs;
    public int poolSize = 100;

    private Dictionary<GameObject, Queue<GameObject>> pool;
    private Dictionary<GameObject, GameObject> instanceToPrefab;

    private void Awake()
    {
        Instance = this;

        pool = new Dictionary<GameObject, Queue<GameObject>>();
        instanceToPrefab = new Dictionary<GameObject, GameObject>();

        InitializePool();
    }

    private void InitializePool()
    {
        foreach (var prefab in prefabs)
        {
            var queue = new Queue<GameObject>();
            pool[prefab] = queue;

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);

                queue.Enqueue(obj);

                instanceToPrefab[obj] = prefab;
            }
        }
    }

    public void Instantiate(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject obj = pool[prefab].Dequeue();
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
    }

    public void Recycle(GameObject obj)
    {
        obj.SetActive(false);

        GameObject prefab = instanceToPrefab[obj];

        pool[prefab].Enqueue(obj);
    }
}
