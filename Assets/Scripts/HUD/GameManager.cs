#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas deathcanvas;
    [SerializeField] private TextMeshProUGUI deathText;
    public int powerUpCounter;
    public List<GameObject> powerUps;
    private int powerUpSpawn = 10;
    public GameObject MaxHealthBoost;
    public GameObject DamageBoost;
    public GameObject SpeedBoost;

    private PlayerController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<PlayerController>();

        powerUpCounter = 0;
        powerUps.Add(MaxHealthBoost);
        powerUps.Add(DamageBoost);
        powerUps.Add(SpeedBoost);

        deathcanvas.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    public void PlayerDeath()
    {
        controller.deathStop();
        Time.timeScale = 0f;
        deathcanvas.enabled = true;  
    }

    public void EnemyDeath(Vector2 enemyPosition)
    {
        int DBNumber = 0;
        int SBNumber = 0;

        powerUpCounter += 1;

        if (powerUpCounter >= powerUpSpawn)
        {
            int RandomIndex = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[RandomIndex], new Vector2(enemyPosition.x, enemyPosition.y), Quaternion.identity);
            powerUpCounter -= powerUpSpawn;

            if (powerUps[RandomIndex] = DamageBoost)
            {
                DBNumber += 1;
            }

            if (powerUps[RandomIndex] = SpeedBoost)
            {
                SBNumber += 1;
            }
            
            if (DBNumber == 3)
            {
                powerUps.Remove(DamageBoost);
            }

            if (SBNumber == 3)
            {
                powerUps.Remove(SpeedBoost);
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Ending()
    {
        ReloadScene();
        Debug.Log("Playing game agian!");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
