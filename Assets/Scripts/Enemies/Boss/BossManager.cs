using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] float health, maxHealth;
    [SerializeField] public GameObject particlePrefab;
    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] private Canvas BossWincanvas;

   

    private PlayerController playerController;

    private GameManager gmanager;

    public static bool shootAttack = false;
    public static bool lungeAttack = true;
    public bool  bossDead = false;

    private void Start()
    {
        StartCoroutine(SwitchAttacks());
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);

        playerController = FindFirstObjectByType <PlayerController>();
        gmanager = FindFirstObjectByType<GameManager>();

        healthBar = GetComponentInChildren<FloatingHealthBar>();

        BossWincanvas.enabled = false;

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
        healthBar.UpdateHealthBar(health, maxHealth);

        damageParticle();

        if (health <= 0)
        {
           // gmanager.PlayerDeath();
            Destroy(gameObject);
            bossDead = true;
            gmanager.PlayerWin();
        }
    }

    public void BossWin()


    {
        if (bossDead == true)
        {
            BossWincanvas.enabled = true;
        }
        
    }

    public void damageParticle()
    {
        GameObject partcicleinstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(partcicleinstance, 1.5f);
    }

    #endregion

}
