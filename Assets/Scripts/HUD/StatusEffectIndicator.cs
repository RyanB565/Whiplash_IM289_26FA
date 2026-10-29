using System.Collections;
using UnityEngine;

public class StatusEffectIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicatorEffect;
    public bool isFinished;

    private void Start()
    {
         
    }

    public void StartIndicatorEffect(float duration)
    {
        isFinished = true;
        indicatorEffect.SetActive(false);
        indicatorEffect.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().
            ActivateCountdown(duration);

        StartCoroutine(EndIndicatorEffect(duration));
    }

    IEnumerator EndIndicatorEffect(float delay)
    {
        yield return new WaitForSeconds(delay);

        isFinished = false;
        indicatorEffect.SetActive(false);
    }
}
