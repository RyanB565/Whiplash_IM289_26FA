using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    private bool isActive = false;
    private float indicatorTimer;
    private float maxIndicatorTimer;
    private Image radialProgressBar;

    private void Awake()
    {
        radialProgressBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (isActive)
        {
            indicatorTimer -= Time.deltaTime;
            radialProgressBar.fillAmount = (indicatorTimer / maxIndicatorTimer);

            if (indicatorTimer <= 0)
            {
                StopCountdown();
            }
        }
    }

    public void ActivateCountdown(float countdownTime)
    {
        isActive = true;
        maxIndicatorTimer = countdownTime;
        indicatorTimer = maxIndicatorTimer;

        radialProgressBar.fillAmount = 1f;
    }

    public void StopCountdown()
    {
        isActive = false;
        indicatorTimer = 0f;
        radialProgressBar.fillAmount = 0f;
    }
}
