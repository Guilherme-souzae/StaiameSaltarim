using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp = 10;
    public GameObject gemPrefab;
    protected Rigidbody2D rb;
    protected BaseGun[] guns;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        guns = GetComponentsInChildren<BaseGun>();
    }

    protected void Start()
    {
        StartCoroutine(Behavior());
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            hp--;
            ObjectPool.Instance.Recycle(collision.gameObject);
            if (hp <= 0)
            {
                Instantiate(gemPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    protected virtual IEnumerator Behavior()
    {
        yield return null;
    }
}
