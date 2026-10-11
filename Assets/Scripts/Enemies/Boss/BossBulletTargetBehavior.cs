using System;
using UnityEngine;

public class BossBulletTargetBehavior : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Destroy(gameObject);
            return;     
        }

        direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * bulletSpeed * Time.deltaTime);

        rb.linearVelocity = direction * bulletSpeed;
    }
}
