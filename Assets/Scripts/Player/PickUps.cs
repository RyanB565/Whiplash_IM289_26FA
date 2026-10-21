using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealth playerHealth;
    
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickUp"))
        {
            playerHealth.Refill();
            Debug.Log("Healed!");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            playerHealth.ExtraHearts();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DamageBoost"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            playerController.moveSpeed += 1f;
            Destroy(collision.gameObject);
        }
    }
}
