using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlashAttack : MonoBehaviour
{
  
    public float slashCooldown = 1f;
    private InputAction slash;
    private Vector2 facingDirection = Vector2.right;
    public GameObject attackboxPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        slash = InputSystem.actions.FindAction("Slash");
        slash.performed += Slash_performed;
        
    }

    private void Slash_performed (InputAction.CallbackContext context)
    {
        StartCoroutine(Attackbox());
    }

  
    IEnumerator Attackbox()
    {
        Vector3 spawnPos = new Vector3(facingDirection.x, facingDirection.y, 0f); //player move direction

        GameObject attackbox = Instantiate(attackboxPrefab, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(0.15f);

        Destroy(attackbox);
    }

}
