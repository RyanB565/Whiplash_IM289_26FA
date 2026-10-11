using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;

    private Transform target;
    private CapacitySystem capacitySystem;
    private PickUps pickUps;
    private SpriteRenderer sr;
    private Vector2 lastPosition;

    [SerializeField] float health, maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        capacitySystem = FindFirstObjectByType<CapacitySystem>();

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
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void Die()
    {
        //pickUps.PickupCount();
    }

    #region Enemies Health Method

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);

            if (capacitySystem != null)
            {
                capacitySystem.EnemyDied(gameObject);
            }
        }
    }

    #endregion
}
