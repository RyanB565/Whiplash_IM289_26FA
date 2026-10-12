using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static bool shootAttack = false;
    public static bool lungeAttack = true;
    private void Start()
    {
        StartCoroutine(SwitchAttacks());
    }

    private IEnumerator SwitchAttacks()
    {
        while (true)
        {
            shootAttack = !shootAttack;
            lungeAttack = !lungeAttack;
            yield return new WaitForSeconds(5);
        }
    }

}
