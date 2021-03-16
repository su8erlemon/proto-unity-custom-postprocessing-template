using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(M65NoiseRenderer), PostProcessEvent.BeforeStack, "Custom/SS/M65Noise")]
public sealed class M65Noise : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("M65Noise effect intensity.")]
    public FloatParameter intensity = new FloatParameter { value = 0.0f };

    [Range(0f, 20f), Tooltip("M65Noise effect intensity.")]
    public FloatParameter screenIntensity = new FloatParameter { value = 0.0f };

    [Range(0f, 1f), Tooltip("Params")]
    public Vector4Parameter params1 = new Vector4Parameter { value = new Vector4(0, 0, 0, 0) };

    // public TextureParameter cgDepthTexture = new TextureParameter
    // {
    //     value = null,
    //     defaultState = TextureParameterDefault.Black
    // };
}

public sealed class M65NoiseRenderer : PostProcessEffectRenderer<M65Noise>
{
    public override void Render(PostProcessRenderContext context)
    {
        context.command.BeginSample("M65Noise");

        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/SS/M65Noise"));
        sheet.properties.SetFloat("_Intensity", settings.intensity);
        sheet.properties.SetVector("_Params1", settings.params1);
        sheet.properties.SetFloat("_ScreenIntensity", settings.screenIntensity);
        // sheet.properties.SetTexture("_CGDepthTexture", settings.cgDepthTexture);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        context.command.EndSample("M65Noise");
    }
}