using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    public GameManager gameManager;
    public GameObject healthPickup;
    private Transform target;
    private CapacitySystem capacitySystem;
    private SpriteRenderer sr;
    private Vector2 lastPosition;
    [SerializeField] public GameObject particlePrefab;
    [SerializeField] float health, maxHealth;
    private Animator animator;
    [SerializeField] private AudioSource hitSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        capacitySystem = FindFirstObjectByType<CapacitySystem>();
        gameManager = FindFirstObjectByType<GameManager>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float moveDeltaX = transform.position.x - lastPosition.x;
        if (moveDeltaX != 0)
        {
            sr.flipX = moveDeltaX < 0;
        }

        lastPosition = transform.position;

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            animator.SetBool("Hit", false);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Hit", true);
        }
    }

    #region Enemies Health Method

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        damageParticle();
        DamageSfx();

        if (health <= 0)
        {

            Destroy(gameObject);
            
            if (capacitySystem != null)
            {
                capacitySystem.EnemyDied(gameObject);
            }

            gameManager.EnemyDeath(gameObject.transform.position);

            int HealthRoll = UnityEngine.Random.Range(1, 11);

            if (HealthRoll == 10)
            {
                Instantiate(healthPickup, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
        }
    }
    public void DamageSfx()
    {
        hitSound.Play();
    }


    public void damageParticle()
    {
        GameObject partcicleinstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        Destroy(partcicleinstance, 1.5f);
    }
    #endregion
}
