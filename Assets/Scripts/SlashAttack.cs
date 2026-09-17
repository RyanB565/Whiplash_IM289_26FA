using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlashAttack : MonoBehaviour
{
  
    
    private InputAction slash;
    private InputAction move;
    private Vector2 facingDirection = Vector2.right;
    public GameObject attackboxPrefab;
    public GameObject spawnedboxPrefab;

    [SerializeField] private Animator slashAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        slash = InputSystem.actions.FindAction("Slash");
        slash.performed += Slash_performed;

        move = InputSystem.actions.FindAction("Move");
        move.performed += Move_performed;


    }

    private void Move_performed (InputAction.CallbackContext move)
    {
        Vector2 input = move.ReadValue<Vector2>();

        if(input.sqrMagnitude > 0.01f)
        {
            facingDirection = input.normalized;
        }
    }


    private void Slash_performed (InputAction.CallbackContext context)
    {
        slashAnim.SetTrigger("Slash");
    }

    public void SlashSpawn()
    {
        Vector3 spawnPos = transform.position + new Vector3(facingDirection.x, facingDirection.y, 0f) * 0.5f;

        spawnedboxPrefab = Instantiate(attackboxPrefab, spawnPos, Quaternion.identity);
    }

    public void SlashEnd()
    {
        if (spawnedboxPrefab != null)
        {
            Destroy(spawnedboxPrefab);
        }
    }

}
