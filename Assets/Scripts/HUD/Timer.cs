using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timeEnded;
    public float countdownTime;

    private CapacitySystem capacitySystem;

    private void Start()
    {
        

        timeEnded.text = "";
        timeEnded.enabled = false;

        capacitySystem = FindFirstObjectByType<CapacitySystem>();

        


        
    }


    private void FixedUpdate()
    {

        WaveTimer();


        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(countdownTime, 0);


        int time = Mathf.CeilToInt(countdownTime);

        int minutes = time / 60;
        int seconds = time % 60;



        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);

        if (time == 0)
        {
            timerText.enabled = true;
            timeEnded.text = "Times up";

        }

    }

  

    public void WaveTimer()
    {
        if (capacitySystem.currentWave == 1)
        {
            
            countdownTime = 60f;
        }
        else if (capacitySystem.currentWave == 2)
        {
            
            countdownTime = 90f;
        }
        else if (capacitySystem.currentWave == 3)
        {

            countdownTime = 120f;
        }
        else if (capacitySystem.currentWave == 4)
        {
            countdownTime = 150f;
        }
         else if (capacitySystem.currentWave == 5)
        {
            countdownTime = 180f;
        }

    }
}
