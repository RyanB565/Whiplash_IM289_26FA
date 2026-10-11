using System.Collections;
using UnityEngine;

public class RMEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform playerLoc;
    [SerializeField] private Transform Targeting;
    private Transform enemyLoc;
    private float moveSpeed;
    private bool canShoot = false;
    private CapacitySystem capacitySystem;

    private void Start()
    {
        enemyLoc = GetComponent<Transform>();
        moveSpeed = 2f;
        StartCoroutine(Shooting());
    }

    private void Update()
    {
        //Check distance between the enemy and player
        //and if the enemy is too far from the player make him move towards the player
        float distance = Vector2.Distance(playerLoc.position, enemyLoc.position);
        if (distance > 6)
        {
            canShoot = false;
            transform.position = Vector3.MoveTowards(transform.position, playerLoc.position, moveSpeed * Time.deltaTime);
        }
        if (distance <= 6)
        {
            canShoot = true;
        }
        if (distance < 2)
        {
            canShoot = false;
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            if (canShoot)
            {
                Instantiate(bullet, Targeting.position, Targeting.rotation);
            }

            yield return new WaitForSeconds(1f);

        }
    }

    //public void Die()
    //{
    //    if (capacitySystem != null)
    //    {
    //        capacitySystem.EnemyDied(gameObject);
    //    }

    //    Destroy(gameObject);
    //}
}
