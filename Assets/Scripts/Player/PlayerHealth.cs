using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;
    private HealthHeartManager heartManager;
    private GameManager gameManager;
    [SerializeField] private AudioSource damageSFX;
    [SerializeField] private int totalHearts;
    private Animator hitanim;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitanim = GetComponent<Animator>();
        health = maxHealth;
        heartManager = FindFirstObjectByType<HealthHeartManager>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void TakeDamage(float amount)
    {
        hitanim.SetTrigger("Damaged");
        health -= amount;
        damageSFX.Play();
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (health == 0 && gameManager != null)
        {
            gameManager.PlayerDeath();
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
        if (maxHealth < totalHearts)
        {
            maxHealth += 2;
            heartManager.DrawHearts();
            Refill();
        }

        if (maxHealth == totalHearts)
        {
            Refill();
        }
    }

}
