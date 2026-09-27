using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private Vector2 moveDir;
    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject SoulAttack;
    private GameObject SoulSpawn;

    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            rb2d.linearVelocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }
    }

    public void Knockback(Transform origin, float knockbackPower, float knockbackDuration)
    {
        StartCoroutine(KBRoutine(origin, knockbackPower, knockbackDuration));
    }

    IEnumerator KBRoutine(Transform origin, float knockbackPower, float knockbackDuration)
    {
        canMove = false;

        //calculate knockback direction
        Vector2 direction = (transform.position - origin.position).normalized;
        rb2d.linearVelocity = direction * knockbackPower;

        yield return new WaitForSeconds(knockbackDuration);

        rb2d.linearVelocity = Vector2.zero;
        canMove = true;
    }

    public void Soul()
    {
        SoulSpawn =  Instantiate(SoulAttack, transform);
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void SoulDestroy()
    {
        if(SoulSpawn != null)
        {
            Destroy(SoulSpawn);
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
    
}
