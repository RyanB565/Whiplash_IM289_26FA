using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private Vector2 moveDir;
    private Rigidbody2D rb2d;
    [SerializeField] public float moveSpeed;
    [SerializeField] private GameObject SoulAttack;
    private GameObject SoulSpawn;
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
        rb2d.linearVelocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
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
