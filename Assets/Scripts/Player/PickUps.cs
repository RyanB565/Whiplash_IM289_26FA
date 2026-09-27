using UnityEngine;

public class PickUps : MonoBehaviour
{

    public PlayerController playerController;
    public SlashAttack slashAttack;
    public SoulAttack soulAttack;
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
            playerHealth.health += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            playerHealth.maxHealth += 1f;
            Destroy(collision.gameObject);
        }

        //if (collision.CompareTag("DamageBoost"))
        {
            //slashAttack.slashDamage += 1f;
            //soulAttack.soulDamage += 1f;
            //Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            playerController.moveSpeed += 1f;
            Destroy(collision.gameObject);
        }
    }
}
