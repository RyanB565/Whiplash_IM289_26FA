using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public List<GameObject> powerUps;
    private int EnemiesKilled;
    public GameObject healthPickup;
    public GameObject MaxHealthBoost;
    public GameObject DamageBoost;
    public GameObject SpeedBoost;

    void Start()
    {
        EnemiesKilled = 0;
    }

    
    void Update()
    {
        
    }

    public void EnemyDeath()
    {
        EnemiesKilled += 1;

        if (EnemiesKilled >= 10)
        {
            int RandomIndex = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[RandomIndex], new Vector2(1, 0), Quaternion.identity);
        }

        int HealthRoll = Random.Range(1, 10);

        if (HealthRoll == 10)
        {
            Instantiate(healthPickup, new Vector2(1, 0), Quaternion.identity);
        }

    }
}
