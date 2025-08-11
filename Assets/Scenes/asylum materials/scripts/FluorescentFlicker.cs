using UnityEngine;

public class FluorescentFlicker : MonoBehaviour
{
    public Light flickerLight; // Assign in Inspector
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float noiseSpeed = 1.0f;
    public float glitchChance = 0.02f; // Probability of sudden dip per frame
    public float glitchDuration = 0.05f;

    private float noiseOffset;
    private float glitchTimer = 0f;
    private bool inGlitch = false;

    void Start()
    {
        if (flickerLight == null)
            flickerLight = GetComponent<Light>();

        // Random start offset so multiple lights don't sync
        noiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (inGlitch)
        {
            glitchTimer -= Time.deltaTime;
            if (glitchTimer <= 0f)
                inGlitch = false;
            else
                return; // Keep light dimmed during glitch
        }

        // Smooth base flicker
        float noiseValue = Mathf.PerlinNoise(noiseOffset, Time.time * noiseSpeed);
        flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noiseValue);

        // Random glitch trigger
        if (Random.value < glitchChance * Time.deltaTime * 60f) // Frame-rate normalized
        {
            StartGlitch();
        }
    }

    void StartGlitch()
    {
        inGlitch = true;
        glitchTimer = glitchDuration;
        flickerLight.intensity = Random.Range(0.1f, 0.4f); // Sudden dim
    }
}