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
   
    private float lungeTimeRemaining;
    private float lungeTimer;
    private Vector3 lungeTarget;
    private bool canLunge = true;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        enemyLoc = GetComponent<Transform>();

        moveSpeed = 2f;



    }

    // Update is called once per frame
    void Update()
    {
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
            transform.position = Vector3.MoveTowards( transform.position, lungeTarget, lungeSpeed * 
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
            transform.position = Vector3.MoveTowards( transform.position, playerLoc.position, moveSpeed * 
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

