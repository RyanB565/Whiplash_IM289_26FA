using Unity.VisualScripting;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{

    [SerializeField] private AttackType attackType;

    public enum AttackType { Slash, Soul }
    private PlayerController pController;

    public float DamageAmount { get { if (attackType == AttackType.Slash) 
            { return pController.SlashDamage; } return pController.SoulDamage; } }

    private void Awake()
    {
        pController = FindFirstObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyComponent))
        {
            enemyComponent.TakeDamage(DamageAmount);
        }

        if (collision.gameObject.TryGetComponent<RangedEnemyController>(out RangedEnemyController RenemyComponent))
        {
            RenemyComponent.TakeDamage(DamageAmount);
        }

        if (collision.gameObject.TryGetComponent<BossManager>(out BossManager BossComponent))
        {
            BossComponent.TakeDamage(DamageAmount);
        }

    }
}
