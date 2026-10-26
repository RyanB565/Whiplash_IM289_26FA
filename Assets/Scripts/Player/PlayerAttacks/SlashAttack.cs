using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlashAttack : MonoBehaviour
{
    private InputAction slash;
    private InputAction move;

    [SerializeField] private AudioSource slashFX;

    private Vector2 facingDirection = Vector2.right;

    public GameObject attackboxPrefab;
    public GameObject spawnedboxPrefab;

    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private SpriteRenderer  slashSprite;
    [SerializeField] private Animator slashAnim;
    private bool CanSlash = true;
    private bool isRoutineRunning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        isRoutineRunning = false;
        CanSlash = true;
        slash = InputSystem.actions.FindAction("Slash");
        slash.performed += Slash_performed;

        move = InputSystem.actions.FindAction("Move");
        move.performed += Move_performed;

        slashSprite = GetComponent<SpriteRenderer>();

    }

    private void Move_performed (InputAction.CallbackContext move)
    {
        Vector2 input = move.ReadValue<Vector2>();
        if (input.sqrMagnitude > 0.01f)
        {
            facingDirection = input.normalized;
        }   
    }
    
    private void Slash_performed (InputAction.CallbackContext context)
    {
        if (CanSlash && slashAnim != null)
        {
            CanSlash = false;
            slashAnim.SetTrigger("Slash");
            if (isRoutineRunning)
            {
                return;
            }
            else
            {
                StartCoroutine(SlashCooldown());
            }

        }
    }

    public void SlashSpawn()

    {
       
        Vector2 directionface = new Vector2(facingDirection.y, -facingDirection.x);


        Vector3 spawnPos = transform.position + new Vector3(facingDirection.x, facingDirection.y,0f)
            * distanceFromPlayer;


        Quaternion rot = Quaternion.LookRotation(-Vector3.forward, directionface);
        spawnedboxPrefab = Instantiate(attackboxPrefab, spawnPos, rot);

        slashSprite.flipX = facingDirection.x < 0f;
        slashSprite.flipY = false;
        
    }

    public void SlashEnd()
    {
        if (spawnedboxPrefab != null)
        {
            Destroy(spawnedboxPrefab);
        }
    }

    public void SlashSound()
    {
        slashFX.Play();
    }

    private IEnumerator SlashCooldown()
    {
        while (true)
        {
            isRoutineRunning = true;

            yield return new WaitForSeconds(0.8f);
            CanSlash = true;

            isRoutineRunning = false;

        }
    }
}
