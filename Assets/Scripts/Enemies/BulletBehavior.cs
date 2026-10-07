using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    private Rigidbody2D bullet;
    private float speed = 5;
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        bullet.linearVelocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        }
        
    }
}
