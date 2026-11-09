using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private float musicVolume = 1f;

    private Coroutine musicCoroutine;
 
    public void BackgroundMusicPlay(float stopTime)
    {
        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }

        musicCoroutine = StartCoroutine(PlayAndStop(stopTime));
    }

    private IEnumerator PlayAndStop(float stopTime)
    {
        musicSource.volume = musicVolume;
        musicSource.time = 0f;
        musicSource.Play();

        float waitTime = Mathf.Max(0f, stopTime - fadeDuration);
        yield return new WaitForSeconds(waitTime);

        float startVolume = musicVolume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeDuration);
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
        musicCoroutine = null;
    }

    public void StopNow()
    {
        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
            musicCoroutine = null;
        }

        musicSource.Stop();
    }
}
