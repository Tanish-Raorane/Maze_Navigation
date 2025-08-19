using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EmissionFlicker : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color emissionColor = Color.white;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 5f;

    private Material mat;

    void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        // Use the material instance, not the shared material
        mat = targetRenderer.material;
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        Color finalColor = emissionColor * intensity;
        mat.SetColor("_EmissionColor", finalColor);

        // Required so Unity updates the emission in real time
        DynamicGI.SetEmissive(targetRenderer, finalColor);
    }
}