using UnityEngine;

public class ParryControler : MonoBehaviour
{
    [Header("Configurações")]
    public float maxCooldown = 0f;
    public float parryDuration = 10f;

    [Header("Estado Atual")]
    private float currentCooldown = 0f;
    private float parryTimer = 0f;
    private bool isParrying = false;

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z) && currentCooldown <= 0)
        {
            StartParry();
        }

        if (isParrying)
        {
            parryTimer -= Time.deltaTime;
            if (parryTimer <= 0)
            {
                isParrying = false;
            }
        }
    }

    void StartParry()
    {
        isParrying = true;
        parryTimer = parryDuration;
        currentCooldown = maxCooldown;
        Debug.Log("Parry Ativado!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parryable") && isParrying)
        {
            Debug.Log("Projétil Parried!");
            GameObject projectile = other.gameObject;
            float hitX = projectile.transform.position.x - transform.position.x;
            float halfWidth = GetComponent<Collider2D>().bounds.size.x / 2f;
            float normalizedHit = hitX / halfWidth;
            projectile.GetComponent<ParryProjectile>().Parry(normalizedHit);
        }
    }
}