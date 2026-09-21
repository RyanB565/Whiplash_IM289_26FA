using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float currentHealth = 1f;
    [SerializeField] float maxHealth = 1f;
    [SerializeField] float damage = 1f;
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickUp"))
        {
            currentHealth += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            maxHealth += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DamageBoost"))
        {
            damage += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            moveSpeed += 1f;
            Destroy(collision.gameObject);
        }
    }
}
