using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<ScriptableEnemyAction> actions;

    public int hp = 3;
    private void Start()
    {
        StartCoroutine(RunBehavior());
    }

    private IEnumerator RunBehavior()
    {
        foreach (var action in actions)
        {
            yield return action.CreateAction().Execute(this);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            hp--;
            ObjectPool.Instance.Recycle(collision.gameObject);
            if (hp <= 0)
            {
                ObjectPool.Instance.Recycle(gameObject);
            }
        }
    }
}
