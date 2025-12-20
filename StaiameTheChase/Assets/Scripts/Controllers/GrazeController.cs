using UnityEngine;

public class GrazeController : MonoBehaviour
{
    private bool grazed = false;

    private void FixedUpdate()
    {
        if (grazed)
        {
            PointsManager.Instance.Graze++;
            grazed = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            grazed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") && grazed)
        {
            grazed = false;
        }
    }
}
