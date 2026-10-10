using Unity.VisualScripting;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    public void DamageBoost()
    {
        if (damageAmount <= 4)
        {
            return;
        }

        damageAmount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyComponent))
        {
            enemyComponent.TakeDamage(damageAmount);
        }

        if (collision.gameObject.TryGetComponent<RangedEnemyController>(out RangedEnemyController RenemyComponent))
        {
            RenemyComponent.TakeDamage(damageAmount);
        }
    }
}
