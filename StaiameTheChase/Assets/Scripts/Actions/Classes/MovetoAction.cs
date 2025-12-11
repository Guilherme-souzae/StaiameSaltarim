using UnityEngine;
using System.Collections;

public class MovetoAction : IEnemyAction
{
    public Vector2 target;
    public float duration;

    public IEnumerator Execute(EnemyController enemy)
    {
        Vector2 start = enemy.transform.position;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            enemy.transform.position = Vector2.Lerp(start, target, t / duration);
            yield return null;
        }
    }
}
