using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using System;

public class CapacitySystem : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    [SerializeField] private int currentWave;
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private float waveTimer;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int waveDuration;

    private int waveValue;
    private float spawnInterval;
    public int spawnIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateWave();
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        //Gives a fixed time beetween each enemies 
        spawnInterval = waveDuration / enemiesToSpawn.Count;

        waveTimer = waveDuration;
    }

    private void GenerateEnemies()
    {
        List<GameObject> generateEnemies = new List<GameObject>();

        while(waveValue > 0 || generateEnemies.Count < 50)
        {
            //int randEnemyId = Random.Range(0, enemies.Count);
            //int randEnemyCapacityCost = enemies[randEnemyId].capactiyCost;

            //if(waveValue -= randEnemyCapacityCost >= 0)
            {

            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            //spawns the enemy
            if (enemiesToSpawn.Count > 0)
            {
                //spawns the first enemy in the list
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocations[spawnIndex].position, Quaternion.identity);

                //then removes it 
                enemiesToSpawn.RemoveAt(0);
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                if (spawnIndex + 1 <= spawnLocations.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                //when no enemies remain then the spwaning ends 
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {
            currentWave++;
            GenerateWave();
        }
    }

    [System.Serializable]
    public class Enemy
    {
        [SerializeField] public GameObject enemyPrefab;
        [SerializeField] public int capactiyCost;
    }
}
