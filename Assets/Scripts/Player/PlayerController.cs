using System.Collections;
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
    private Animator anim;

    private bool canMove = true;

    #region Start Methods

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Move");
    }

    private void OnEnable()
    {
        move.Enable();
        move.canceled += Move_canceled;
    }

    private void OnDisable()
    {
        move.canceled -= Move_canceled;
        move.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        move.started += Move_started;
        move.canceled += Move_canceled;
    }

    #endregion

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        if (anim != null)
        {
            anim.SetBool("Walking", false);
        }
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        if (anim != null)
        {
            anim.SetBool("Walking", true);
        }
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

    #region Knockback Method

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

    #endregion

    #region Attacking Methods

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
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    #endregion

    public void deathStop()
    {
        move.started -= Move_started;

        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
    }
    
}
