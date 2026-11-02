using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealth playerHealth;
    private UIGameManager uiGameManager;
    [SerializeField] private AudioSource pickUpsSound;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        uiGameManager = FindFirstObjectByType<UIGameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickUp"))
        {
            playerHealth.Refill();
            PickUpsSfx();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("MaxHealthBoost"))
        {
            playerHealth.ExtraHearts();
            PickUpsSfx();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DamageBoost"))
        {
            playerController.DamageBoost();
            PickUpsSfx();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpeedBoost"))
        {
            playerController.moveSpeed += 1f;
            PickUpsSfx();
            Destroy(collision.gameObject);
        }
    }

    private void PickUpsSfx()
    {
        pickUpsSound.Play();
    }
}
