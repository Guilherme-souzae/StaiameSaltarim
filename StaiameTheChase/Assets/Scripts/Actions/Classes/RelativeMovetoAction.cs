using UnityEngine;
using System.Collections;

public class RelativeMovetoAction : IEnemyAction
{
    public Vector2 offset;
    public float duration;

    public IEnumerator Execute(EnemyController enemy)
    {
        Vector2 start = enemy.transform.position;
        Vector2 target = start + offset;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            enemy.transform.position = Vector2.Lerp(start, target, t / duration);
            yield return null;
        }
    }
}
