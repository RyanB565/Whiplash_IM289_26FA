using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class BossRangedAttacks : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform Target;
    [SerializeField] private float distanceFromPlayer;
    //[SerializeField] private float fireRate;

    private Transform playerLocation;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerLocation = player.transform;
        StartCoroutine(Shooting());
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    float distance = Vector2.Distance(
    //        playerLocation.position, transform.position);

    //    canShoot = distance <= distanceFromPlayer;
    //}

    private IEnumerator Shooting()
    {
        while (true)
        {
            if (bulletPrefab != null && Target != null)
            {
                Vector2 direction = (playerLocation.position - Target.position).normalized;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Quaternion rotation = Quaternion.Euler(0f, 0f, angle - 90f);

                Instantiate(bulletPrefab, Target.position, rotation);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
