using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Starting Health is used for testing at the moment
    public float health, maxHealth, startingHealth;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = startingHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if(health <= 0)
        {
            health = 0;
            Debug.Log("You died, haha");
            OnPlayerDeath?.Invoke();
        }
    }

    //Power-Up Method 
    public void HealthPickup()
    {

    }

}
