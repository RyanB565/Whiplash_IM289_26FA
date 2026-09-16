using UnityEngine;
using UnityEngine.InputSystem;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private Animator AoEAnim;
    private InputAction AoE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AoE = InputSystem.actions.FindAction("Soul");
        AoE.performed += AoE_performed;
    }

    private void AoE_performed(InputAction.CallbackContext obj)
    {
        AoEAnim.SetTrigger("Soul");
    }






}
