using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] float health, maxHealth;

    public static bool shootAttack = false;
    public static bool lungeAttack = true;
    private void Start()
    {
        StartCoroutine(SwitchAttacks());
        health = maxHealth;
    }

    private IEnumerator SwitchAttacks()
    {
        while (true)
        {
            shootAttack = !shootAttack;
            lungeAttack = !lungeAttack;
            yield return new WaitForSeconds(5);
        }
    }

    #region Boss Health Method

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion

}
