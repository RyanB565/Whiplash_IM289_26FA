using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public List<GameObject> powerUps;
    public GameManager gameManager;
    private int powerUpSpawn = 10;
    public Transform enemy;

    public GameObject healthPickup;
    public GameObject MaxHealthBoost;
    public GameObject DamageBoost;
    public GameObject SpeedBoost;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        powerUps.Add(MaxHealthBoost);
        powerUps.Add(DamageBoost);
        powerUps.Add(SpeedBoost);
    }


    void Update()
    {

    }

    public void DeathMath()
    {
        if (gameManager.powerUpCounter >= powerUpSpawn)
        {
            int RandomIndex = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[RandomIndex]);
            gameManager.powerUpCounter -= powerUpSpawn;
        }

        int HealthRoll = Random.Range(1, 11);

        if (HealthRoll == 10)
        {
            Instantiate(healthPickup, new Vector2(1, 0), Quaternion.identity);
        }

    }
}
