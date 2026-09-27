using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.Die();
            Debug.Log("Killed");
        }
    }
}
