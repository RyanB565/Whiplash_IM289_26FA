using UnityEngine;
using UnityEngine.Rendering;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float knockbackPower;
    [SerializeField] private float knockbackDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }

        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.Knockback(transform, knockbackPower, knockbackDuration);
        }

    }


}
