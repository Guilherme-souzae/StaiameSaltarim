using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject heart;

    public float speed = 5f;
    public float grazeSpeed = 1f;
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, v, 0f).normalized;
        transform.position += (Input.GetKey(KeyCode.LeftShift)) ? dir * grazeSpeed * Time.deltaTime : dir * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            heart.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            heart.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que encostou tem a tag
        if (other.CompareTag("EnemyProjectile"))
        {
            ObjectPool.Instance.Recycle(other.gameObject);
        }
    }
}
