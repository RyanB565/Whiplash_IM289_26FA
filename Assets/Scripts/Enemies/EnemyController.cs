using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;

    private Transform target;
    private CapacitySystem capacitySystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        capacitySystem = FindFirstObjectByType<CapacitySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void Die()
    {
        if (capacitySystem != null)
        {
            capacitySystem.EnemyDied(gameObject);
        }

        Destroy(gameObject);
    }
}
