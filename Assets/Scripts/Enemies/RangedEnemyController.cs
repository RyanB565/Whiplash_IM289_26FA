using System.Collections;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float health, maxHealth;
    public EnemyDrops enemyDrops;

    private Transform playerLoc;
    [SerializeField] private Transform Targeting;
    private Transform enemyLoc;
    private float moveSpeed;
    private bool canShoot = false;
    private CapacitySystem capacitySystem;
    [SerializeField] public GameObject particlePrefab;
    private void Start()
    {
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        enemyLoc = GetComponent<Transform>();
        moveSpeed = 2f;
        StartCoroutine(Shooting());

        health = maxHealth;
    }

    private void Update()
    {
        //Check distance between the enemy and player
        //and if the enemy is too far from the player make him move towards the player
        float distance = Vector2.Distance(playerLoc.position, enemyLoc.position);
        if (distance > 5)
        {
            canShoot = false;
            transform.position = Vector3.MoveTowards(transform.position, playerLoc.position, moveSpeed * Time.deltaTime);
        }
        if (distance <= 5)
        {
            canShoot = true;
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            if (canShoot)
            {
                Instantiate(bullet, Targeting.position,Targeting.rotation);
            }
            
            yield return new WaitForSeconds(1f);
            
        }
    }

    public void Die()
    {
        enemyDrops.EnemyDeath();
        Destroy(gameObject);
    }

    #region Enemies Health Method

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        damageParticle();

        if (health <= 0)
        {
            Destroy(gameObject);

            if (capacitySystem != null)
            {
                capacitySystem.EnemyDied(gameObject);
            }
        }
    }

    public void damageParticle()
    {
        GameObject partcicleinstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        Destroy(partcicleinstance, 1.5f);
    }


    #endregion

}
