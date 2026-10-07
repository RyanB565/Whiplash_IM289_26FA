using UnityEngine;
using UnityEngine.LowLevel;

public class TargetingBehavior : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    //Rotate towards the player constantly
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 direction = player.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);
        transform.rotation = targetRotation;
    }
}
