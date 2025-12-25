using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class YamuraiEnemi : EnemyController
{
    public float fallSpeed = 2f;

    private bool isFolowing = false;
    private bool isAiming = false;
    private int hpBuffer;

    protected override IEnumerator Behavior()
    {
        rb.linearVelocityY = -fallSpeed;
        StartCoroutine(StartPingPong());
        yield break;
    }
    protected void Start()
    {
        hp = StartingHp;
        hpBuffer = hp;
        StartCoroutine(Behavior());
    }

    private void Update()
    {
        if (isFolowing)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector3 position = transform.position;
                position.x = -player.transform.position.x;
                transform.position = position;
            }
        }

        if (isAiming)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector3 direction = player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
            }
        }
    }

    private IEnumerator StartPingPong()
    {
        isFolowing = false;
        isAiming = true;
        yield return new WaitForSeconds(1f);
        rb.linearVelocity = Vector2.zero;
        guns[0].tryShoot();
        isAiming = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        yield return new WaitForSeconds(0.2f);
        isFolowing = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parryable"))
        {
            if (4 - hp > 0)
            {
                Debug.Log("Projétil Parried!");
                GameObject projectile = other.gameObject;
                float hitX = projectile.transform.position.x - transform.position.x;
                float halfWidth = GetComponent<Collider2D>().bounds.size.x / 2f;
                float normalizedHit = hitX / halfWidth;
                projectile.GetComponent<ParryProjectile>().Parry(-normalizedHit);
            }
            else
            {
                hp -= 1;
                ObjectPool.Instance.Recycle(other.gameObject);
            }
        }
    }

    public void RestartPingPong()
    {
        hp += 1;
        StartCoroutine(StartPingPong());
    }
}