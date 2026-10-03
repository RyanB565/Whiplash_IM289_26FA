using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timeEnded;
    [SerializeField] private float startingTime;
    [SerializeField] private float timeIncrease;
    [SerializeField] private float waveCompleteUpTime;

    public float countdownTime;
    private bool timeFinished;

    private CapacitySystem capacitySystem;

    void Start()
    {
        countdownTime = startingTime;

        timeEnded.text = "";
        timeEnded.enabled = false;
        timeFinished = false;

        capacitySystem = FindFirstObjectByType<CapacitySystem>();
    }

    void FixedUpdate()
    {
        if (timeFinished)
        {
            return;
        }

        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(countdownTime, 0);


        int time = Mathf.CeilToInt(countdownTime);

        int minutes = time / 60;
        int seconds = time % 60;


        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);

        //Calls the wave system when the timer ends and goes to the next wave
        if (time == 0)
        {
            timeFinished = true;
            timerText.enabled = false;
            timeEnded.enabled = true;
            timeEnded.text = "Wave Completed";

            StartCoroutine(WaveComplete());
        }
    }

    /// <summary>
    /// Removes the wave complete text after a couple seconds when wave ends
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaveComplete()
    {
        yield return new WaitForSeconds(waveCompleteUpTime);

        timeEnded.enabled = false;
        timeEnded.text = "";
        

        capacitySystem.WaveSystem();
    }

    public void WaveTimer()
    {
        if (capacitySystem == null)
        {
            return;
        }

        //Adds time based on wave and timeIncrease (Ex. Wave 2 * 30 = 60 + startingTime(60) = 120)
        countdownTime = startingTime + (capacitySystem.currentWave * timeIncrease);

        timerText.enabled = true;
        timeFinished = false;

    }
}
