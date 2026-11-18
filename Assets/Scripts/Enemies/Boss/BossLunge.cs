using UnityEngine;

public class BossLunge : MonoBehaviour
{

    private float moveSpeed;
    private Transform playerLoc;
    private Transform enemyLoc;
    [SerializeField] private Transform Targeting;

    [SerializeField] private float lungeDuration = 0.5f;
    [SerializeField] private float lungeCooldown = 5f;
    [SerializeField] private float lungeSpeed = 8f;
    [SerializeField] private float attackRange = 4f;

    private bool isLunging;
    private bool playerInRange;
    private Vector2 lastPosition;
   
    private float lungeTimeRemaining;
    private float lungeTimer;
    private Vector3 lungeTarget;
    private bool canLunge = true;
    private SpriteRenderer sr;
    private Animator animator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();    
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        enemyLoc = GetComponent<Transform>();

        moveSpeed = 2f;



    }

    // Update is called once per frame
    void Update()
    {
        if (BossManager.lungeAttack)
        {
            animator.SetBool("Ranged",false);
            float distance = Vector2.Distance(playerLoc.position, enemyLoc.position);

            // Handle cooldown
            if (!canLunge)
            {
                lungeTimer += Time.deltaTime;

                if (lungeTimer >= lungeCooldown)
                {
                    canLunge = true;
                    lungeTimer = 0f;
                }
            }

            // Handle lunge movement
            if (isLunging)
            {
                transform.position = Vector3.MoveTowards(transform.position, lungeTarget, lungeSpeed *
                Time.deltaTime);

                lungeTimeRemaining -= Time.deltaTime;

                if (lungeTimeRemaining <= 0f)
                {
                    isLunging = false;
                }

                return;
            }

            // Chase player
            if (distance > attackRange)
            {
                float moveDeltaX = transform.position.x - lastPosition.x;
                if (moveDeltaX != 0)
                {
                    sr.flipX = moveDeltaX > 0;
                }

                lastPosition = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, playerLoc.position, moveSpeed *
                Time.deltaTime);
            }
            // Lunge if in range and cooldown is finished
            else if (canLunge)
            {
                lungeTarget = playerLoc.position;
                isLunging = true;
                canLunge = false;

                lungeTimeRemaining = lungeDuration;
                lungeTimer = 0f;
            }
        }
        
    }
}

