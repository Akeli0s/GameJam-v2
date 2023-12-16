using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class FlickerEffect : MonoBehaviour
{
    public Light2D globalLight;
    public float baseIntensity = 1.0f;
    public float flickerInterval = 2.0f;
    public float intensityVariation = 0.5f; // Adjust the variation in intensity
    public float durationVariation = 0.2f; // Adjust the variation in duration
    public float flickerDuration;
    public float transitionSmoothness = 0.1f; // Adjust the smoothness of transition
    public float lowIntensityLimit = 0.1f; // Adjust the minimum intensity limit

    private void Start()
    {
        // Start the flickering coroutine
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            // Randomize intensity and duration
            float randomIntensity = Random.Range(baseIntensity - intensityVariation, baseIntensity + intensityVariation);
            float randomDuration = Random.Range(flickerDuration - durationVariation, flickerDuration + durationVariation);

            // Ensure that random intensity doesn't go below the specified limit
            randomIntensity = Mathf.Max(randomIntensity, lowIntensityLimit);

            // Smoothly transition to the new intensity
            StartCoroutine(ChangeIntensitySmoothly(randomIntensity, transitionSmoothness));

            // Wait for the specified duration before the next flicker
            yield return new WaitForSeconds(randomDuration);

            // Smoothly transition back to the base intensity
            StartCoroutine(ChangeIntensitySmoothly(baseIntensity, transitionSmoothness));

            // Wait for the specified interval before the next flicker
            yield return new WaitForSeconds(flickerInterval);
        }
    }

    IEnumerator ChangeIntensitySmoothly(float targetIntensity, float smoothness)
    {
        float startIntensity = globalLight.intensity;
        float currentTime = 0f;

        while (currentTime < smoothness)
        {
            currentTime += Time.deltaTime;
            globalLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, currentTime / smoothness);
            yield return null;
        }

        globalLight.intensity = targetIntensity;
    }
}
