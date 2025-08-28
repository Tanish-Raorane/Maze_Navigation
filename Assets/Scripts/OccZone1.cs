using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OccZone1 : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;      // Assign the audio source for this zone
    public float fadeDuration = 1.5f;

    private Coroutine fadeCoroutine;

    private void Start()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
        audioSource.volume = 0f; // Start muted
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartFade(1f); // Fade in
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartFade(0f); // Fade out
        }
    }

    private void StartFade(float targetVolume)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeToTarget(targetVolume));
    }

    private IEnumerator FadeToTarget(float targetVolume)
    {
        float startVolume = audioSource.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume; // Force exact final volume
    }
}