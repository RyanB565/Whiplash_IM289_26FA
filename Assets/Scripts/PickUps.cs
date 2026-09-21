using UnityEngine;

public class PickUps : MonoBehaviour
{
    //[SerializeField] float currentHealth = 1f;
    //[SerializeField] float maxHealth = 1f;
    //[SerializeField] float slashDamage = 1f;
    //[SerializeField] float soulDamage = 1f;
    //[SerializeField] float moveSpeed = 5f;

    public PlayerController playerController;
    public SlashAttack slashAttack;
    public SoulAttack soulAttack;
    //public PlayerHealth playerHealth;

    void Start()
    {
        //float moveSpeed = playerController.moveSpeed;
        //float slashDamage = slashAttack.
        //float soulDamage = soulAttack.
        //float maxHealth = playerHealth.
        //float currentHealth = playerHealth.
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickUp"))
        {
            //currentHealth += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            //maxHealth += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DamageBoost"))
        {
            //slashDamage += 1f;
            //soulDamage += 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            //moveSpeed += 1f;
            Destroy(collision.gameObject);
        }
    }
}
