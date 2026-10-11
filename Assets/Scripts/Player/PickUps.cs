using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public PlayerController playerController;
    public AttackDamage slashAttackDamage;
    public AttackDamage soulAttackDamage;
    public PlayerHealth playerHealth;
    
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
            playerHealth.Refill();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            playerHealth.ExtraHearts();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DamageBoost"))
        {
            slashAttackDamage.DamageBoost();
            soulAttackDamage.DamageBoost();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            playerController.moveSpeed += 1f;
            Destroy(collision.gameObject);
        }
    }
}
