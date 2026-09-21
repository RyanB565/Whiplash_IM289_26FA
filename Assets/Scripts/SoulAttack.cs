using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private Animator AoEAnim;
    private InputAction AoE;
    private bool AoEEnabled = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AoE = InputSystem.actions.FindAction("Soul");
        AoE.performed += AoE_performed;
    }

    private void AoE_performed(InputAction.CallbackContext obj)
    {
        
        if (AoEEnabled)
        {
            AoEAnim.SetTrigger("Soul");
            AoEEnabled = false;
            StartCoroutine(SoulCooldown());
        }
        
    }

    private IEnumerator SoulCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            AoEEnabled = true;
        }
    }






}
