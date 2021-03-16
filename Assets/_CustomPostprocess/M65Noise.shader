Shader "Hidden/Custom/SS/M65Noise"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
        
        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        
        float _Intensity;
        float _ScreenIntensity;
        float4 _Params1;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float2 uv = i.texcoord;
            
            float screenFade = pow(sin(uv.y*3.14)*sin(uv.x*3.14),_ScreenIntensity);
            float2 noise = float2(1.0,1.0);
            uv = lerp(uv,uv*(1.0+noise),_Intensity *screenFade );
            
			return SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}