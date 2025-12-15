using UnityEngine;

public class GrazeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Graze detected!");
        }
    }
}
