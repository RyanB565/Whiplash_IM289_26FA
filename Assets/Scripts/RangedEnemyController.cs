using System.Collections;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform playerLoc;
    [SerializeField] private Transform Targeting;
    private Transform enemyLoc;
    private float moveSpeed;
    private bool canShoot = false;

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
}
