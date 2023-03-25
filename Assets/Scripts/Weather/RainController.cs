using UnityEngine;

public class RainController : GameBehaviour
{
    [SerializeField]
    ParticleSystem rainParticleSystem;
    [SerializeField]
    float baseIntensity = 20.0f;
    [SerializeField]
    AnimationCurve intensityCurve;
    [SerializeField]
    float transitionDuration = 3f;
    [SerializeField]
    AnimationCurve transitionCurve;

    ParticleSystem.EmissionModule rainEmission;
    float rainIntensity;
    float elapsedTime;

    void Awake()
    {
        rainEmission = rainParticleSystem.emission;
        gameManager.Weather.onRainIntensityUpdated += UpdateIntensity;
    }

    // Transition rain intensity.
    void Update()
    {
        // Calculate percent of transition complete.
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / transitionDuration;

        // Gradually update rain intensity.
        rainEmission.rateOverTime = Mathf.SmoothStep(rainEmission.rateOverTime.constant, rainIntensity, transitionCurve.Evaluate(percentageComplete));

        if (percentageComplete >= 1f)
        {
            // Disable updates.
            this.enabled = false;
        }
    }

    void UpdateIntensity(float intensityPower)
    {
        rainIntensity = intensityCurve.Evaluate(intensityPower);
        elapsedTime = 0f;
        this.enabled = true; // Enable updates.
    }

    void OnDestroy()
    {
        gameManager.Weather.onRainIntensityUpdated -= UpdateIntensity;
    }
}
