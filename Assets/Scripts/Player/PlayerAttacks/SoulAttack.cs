using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private Animator AoEAnim;
    [SerializeField] private AudioSource soulSound;
    private InputAction AoE;
    private bool AoEEnabled;
    private bool isRoutineRunning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AoEEnabled = true;
        isRoutineRunning = false;
        AoE = InputSystem.actions.FindAction("Soul");
        AoE.performed += AoE_performed;
    }

    private void AoE_performed(InputAction.CallbackContext obj)
    {   
        if (AoEEnabled && AoEAnim != null)
        {
            AoEEnabled = false;
            AoEAnim.SetTrigger("Soul");
            if (isRoutineRunning)
            {
                return;
            }
            else
            {
                StartCoroutine(SoulCooldown());
            }
            
        }   
    }
    
    private IEnumerator SoulCooldown()
    {
        while (true)
        {
            isRoutineRunning = true;
            
            yield return new WaitForSeconds(5f);
            AoEEnabled = true;

            isRoutineRunning =false;
        }
    }

    public void soulSFX()
    {
        soulSound.Play();
    }
}
