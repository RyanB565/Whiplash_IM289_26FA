using System.Security.Cryptography;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;

    public PickUps pickUps;
    private Transform target;
    private CapacitySystem capacitySystem;
    private SpriteRenderer sr;
    private Vector2 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        capacitySystem = FindFirstObjectByType<CapacitySystem>();
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public GameObject healthPickup;
    public void Die()
    {
        if (capacitySystem != null)
        {
            capacitySystem.EnemyDied(gameObject);
        }

        int HealthRoll = Random.Range(1, 10);
        
        if(HealthRoll == 10)
        {
            Instantiate(healthPickup, gameObject.transform.position, Quaternion.identity);
        }

        if(pickUps != null)
        {
            pickUps.PickupCount();
        }
        
        Destroy(gameObject);
        
    }
}
