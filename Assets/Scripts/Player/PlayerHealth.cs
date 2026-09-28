using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{ 
    public float health, maxHealth;
    private HealthHeartManager heartManager;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        heartManager = FindFirstObjectByType<HealthHeartManager>();
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
    public void Refill()
    {
        health = maxHealth;
        heartManager.DrawHearts();
    }

    public void ExtraHearts()
    {
        if (maxHealth < 8)
        {
            maxHealth += 2;
            heartManager.DrawHearts();
            Refill();
        }

        if (maxHealth == 8)
        {
            Refill();
        }
    }

}
