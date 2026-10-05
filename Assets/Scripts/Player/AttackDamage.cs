using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        //RangedEnemyController rangedEnemy = collision.GetComponent<RangedEnemyController>();
        //RMEnemyController RMEnemy = collision.GetComponent<RMEnemyController>();

        if (enemy != null)
        {
            enemy.Die();
            //rangedEnemy.Die();
            //RMEnemy.Die();
            Debug.Log("Killed");
        }
    }
}
