using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] float health, maxHealth;
    [SerializeField] public GameObject particlePrefab;
    private PlayerController playerController;

    private GameManager gmanager;

    public static bool shootAttack = false;
    public static bool lungeAttack = true;
    private void Start()
    {
        StartCoroutine(SwitchAttacks());
        health = maxHealth;
        playerController = FindFirstObjectByType <PlayerController>();
        gmanager = FindFirstObjectByType<GameManager>();
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
        playerController.BossTakeDamageSound();

        damageParticle();

        if (health <= 0)
        {
            gmanager.PlayerDeath();
            Destroy(gameObject);
        }
    }

    public void damageParticle()
    {
        GameObject partcicleinstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);


        

        Destroy(partcicleinstance,1.5f);
    }

    #endregion

}
