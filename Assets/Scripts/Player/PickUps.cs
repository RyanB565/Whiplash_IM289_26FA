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
    
    public GameObject healthPickup;
    public GameObject MaxHealthBoost;
    //public GameObject DamageBoost;
    public GameObject SpeedBoost;

    void Start()
    {
        powerUps.Add(MaxHealthBoost);
        //powerUps.Add(DamageBoost);
        powerUps.Add(SpeedBoost);
        
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
            int RandomIndex = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[RandomIndex], new Vector2(1, 0), Quaternion.identity);
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
