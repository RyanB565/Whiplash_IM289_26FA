using System.Collections;
using UnityEngine;

public class StatusEffectIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicatorEffect;
    public bool isFinished;

    private Coroutine indicatorCoroutine;

    private void Start()
    {
         
    }

    public void StartIndicatorEffect(float duration)
    {
        if (indicatorCoroutine != null)
        {
            StopCoroutine(indicatorCoroutine);
        }

        isFinished = true;
        indicatorEffect.SetActive(true);
        indicatorEffect.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().
            ActivateCountdown(duration);

        indicatorCoroutine = StartCoroutine(EndIndicatorEffect(duration));
    }

    IEnumerator EndIndicatorEffect(float delay)
    {
        yield return new WaitForSeconds(delay);

        isFinished = false;
        indicatorEffect.SetActive(false);
        indicatorCoroutine = null;
    }
}
