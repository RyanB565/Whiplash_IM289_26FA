using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private Animator AoEAnim;
    [SerializeField] private AudioSource soulSound;
    [SerializeField] private float soulCooldown;

    private StatusEffectIndicator soulIndicator;
    private InputAction AoE;
    private bool AoEEnabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AoEEnabled = true;
       
        AoE = InputSystem.actions.FindAction("Soul");
        AoE.performed += AoE_performed;

        soulIndicator = FindFirstObjectByType<StatusEffectIndicator>();
    }

    private void AoE_performed(InputAction.CallbackContext obj)
    {
        if (!AoEEnabled || AoEAnim == null) { return; }

        AoEEnabled = false;
        AoEAnim.SetTrigger("Soul");

        soulIndicator.StartIndicatorEffect(soulCooldown);
        StartCoroutine(SoulCooldown());
    }

    private IEnumerator SoulCooldown()
    {
        yield return new WaitForSeconds(soulCooldown);
        AoEEnabled = true;
    }

    public void soulSFX()
    {
        soulSound.Play();
    }
}
