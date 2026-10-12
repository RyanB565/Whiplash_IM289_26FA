using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CapacitySystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int capacitybudget;
        public List<CapacityData> availableEnemies;
    }

    [Header("Waves")]
    [SerializeField] private List<Wave> waves;

    [Header("Gerald(Boss) Settings")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform bossSpawnLocation;

    [Header("Spawn Locations")]
    [Tooltip("Drag your empty 2D GameObjects here to act as spawn points.")]
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnDelay;

    [SerializeField] private List<GameObject> spawnedEnemies = new List<GameObject>();

    private Dictionary<GameObject, int> enemiesCosts =
        new Dictionary<GameObject, int>();

    public int currentWave = 0;
    private int currentCapacity;

    private Timer time;
    private GameManager gManager;

    public IReadOnlyList<Wave> Waves => waves;

    void Start()
    {
        time = FindFirstObjectByType<Timer>();
        gManager = FindFirstObjectByType<GameManager>();

        GenerateEnemiesWave();

        Debug.Log($"There are {Waves.Count} waves in this game");

        if (Waves.Count == 1)
        {
            Debug.Log("Game Ended: Please add 5 total waves");
            EditorApplication.isPlaying = false;
        }
    }

    private void FixedUpdate()
    {
        if (currentWave >= waves.Count - 0)
        {
            gManager.PlayerDeath();
        }
    }

    #region Wave System w/ Timer

    public void WaveSystem()
    {
        currentWave++;

        GenerateEnemiesWave();

        if (time != null)
        {
            time.WaveTimer();
        }
    }

    #endregion

    #region Enemies Spawning Method

    public void GenerateEnemiesWave()
    {
        if (currentWave >= waves.Count)
        {
            return;
        }

        if (currentWave == 4)
        {
            SpawnBoss();
            return;
        }

        Wave wave = waves[currentWave];

        //Give the wave its starting budget.
        currentCapacity = wave.capacitybudget;

        spawnedEnemies.Clear();
        enemiesCosts.Clear();

        StartCoroutine(BuyEnemies(wave));
    }

    private IEnumerator BuyEnemies(Wave wave)
    {
        List<CapacityData> affordableEnemies =
                new List<CapacityData>();

        while (currentCapacity > 0)
        {
            //Find all enemies that can currently be afforded.
            foreach (CapacityData enemies in wave.availableEnemies)
            {
                if (enemies.capacityCost <= currentCapacity)
                {
                    affordableEnemies.Add(enemies);
                }
            }

            //Stop if nothing can be afforded.
            if (affordableEnemies.Count == 0)
            {
                break;
            }

            //Randomly choose one affordable enemy.
            int randomIndex =
                Random.Range(0, affordableEnemies.Count);

            CapacityData chosenEnemies =
                affordableEnemies[randomIndex];

            yield return new WaitForSeconds(spawnDelay);

            //Spend the enemies cost.
            currentCapacity -= chosenEnemies.capacityCost;

            //Spawn the enemies.
            SpawnEnemies(chosenEnemies);
        }
    }

    #endregion

    #region Spawning Method

    private void SpawnEnemies(CapacityData enemies)
    {
        if (currentWave == 5)
        {
            return;
        }

        Vector3 spawnPosition = Vector3.zero;

        // Pick a random spawn point.
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            int randomPointIndex =
                Random.Range(0, spawnPoints.Length);

            spawnPosition =
                spawnPoints[randomPointIndex].position;
        }
        else
        {
            Debug.LogWarning("No spawn points assigned! Spawning at (0,0,0) by default.");
        }

        // Create the Enemy.
        GameObject newEnemies = Instantiate(
            enemies.enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Add it to the spawned enemy list.
        spawnedEnemies.Add(newEnemies);

        // Remember how much this enemies cost.
        enemiesCosts.Add(
            newEnemies,
            enemies.capacityCost
        );
    }

    public void ClearEnemies()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        spawnedEnemies.Clear();
        enemiesCosts.Clear();

        Debug.Log("All the remaining enemies are cleared.");
    }

    #endregion

    #region Boss Spawing Method

    public void SpawnBoss()
    {
        if (bossPrefab == null || bossSpawnLocation == null)
        {
            Debug.Log("Boss Prefab or Boss SpawnLocation is not assigned");
            return;
        }

        Instantiate(bossPrefab, bossSpawnLocation.position, Quaternion.identity);

        Debug.Log("Boss Wave Started");
    }

    #endregion

    #region Death Method

    /// <summary>
    /// Call this in the enemies death script to give back the capacity
    /// </summary>
    /// <param name="deadEnemy"></param>
    public void EnemyDied(GameObject deadEnemy)
    {
        //Make sure this enemy belongs to the spawner.
        if (!enemiesCosts.ContainsKey(deadEnemy))
        {
            return;
        }

        //Get the cost of the enemy that died.
        int returnedCost =
            enemiesCosts[deadEnemy];

        //Return that cost to the budget.
        currentCapacity += returnedCost;

        //Remove the dead enemy from our tracking lists.
        enemiesCosts.Remove(deadEnemy);
        spawnedEnemies.Remove(deadEnemy);

        //Buy a new enemy using the returned budget.
        StartCoroutine(BuyEnemies(waves[currentWave]));

        Debug.Log($"Cacpacity Returned - Total: {currentCapacity} ");
    }

    #endregion

}
