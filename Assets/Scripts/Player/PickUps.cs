using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class PickUps : MonoBehaviour
{
    public List<GameObject> powerUps;
    public PlayerController playerController;
    public SlashAttack slashAttack;
    public SoulAttack soulAttack;
    public PlayerHealth playerHealth;
    public int EnemiesKilled;
    void Start()
    {

         EnemiesKilled = 0;
    }

    void Update()
    {

    }

    public void PickupCount()
    {
        EnemiesKilled += 1;

        if (EnemiesKilled >= 15)
        {

        }
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
