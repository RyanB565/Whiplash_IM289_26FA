using System.Collections;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float health, maxHealth;
    private Transform playerLoc;
    [SerializeField] private Transform Targeting;
    private Transform enemyLoc;
    private float moveSpeed;
    private bool canShoot = false;
    private CapacitySystem capacitySystem;
    [SerializeField] public GameObject particlePrefab;
    private Animator animator;
    private Vector2 lastPosition;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
        animator = GetComponent<Animator>();
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        enemyLoc = GetComponent<Transform>();
        moveSpeed = 2f;
        health = maxHealth;
    }

    private void Update()
    {
        float moveDeltaX = transform.position.x - lastPosition.x;
        if (moveDeltaX != 0)
        {
            sr.flipX = moveDeltaX < 0;
        }
        lastPosition = transform.position;
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
        if (canShoot)
        {
            animator.SetBool("Move", false);
            animator.SetBool("IsShooting", true);
        }
        if (!canShoot)
        {
            animator.SetBool("IsShooting", false);
            animator.SetBool("Move", true);
        }
    }

    public void ShootBullet()
    {
        Instantiate(bullet, Targeting.position, Targeting.rotation);
    }

    public void Die()
    {
        
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
