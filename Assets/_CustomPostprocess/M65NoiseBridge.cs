using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class M65NoiseBridge : MonoBehaviour
{
    public PostProcessVolume volume;
    public M65Noise layer;
    public bool isOn = false;
    public float intensity;
    public float screenIntensity;
    public Vector4 params1;
    // public Texture cgDepthTexture;

    void Start()
    {
        volume = GameObject.Find("Post").GetComponent<PostProcessVolume>();
        if (volume != null) volume.profile.TryGetSettings(out layer);
    }

    void Update()
    {
        if (layer != null && volume != null)
        {
            layer.intensity.value = intensity;
            layer.screenIntensity.value = screenIntensity;
            layer.params1.value = params1;
            // layer.cgDepthTexture.value = cgDepthTexture;
            layer.enabled.value = isOn;
        }
    }
}