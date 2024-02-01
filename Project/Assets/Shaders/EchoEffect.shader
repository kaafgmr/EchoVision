Shader "KelsonShaders/EchoEffect"
{
    Properties
    {
        [HideInInspector]_MainTex ("Albedo (RGB)", 2D) = "white" {}

        [HDR] _EchoEmissionColor("Emmisive Color", Color) = (0,0,0)
        [Toggle(_Debug)] _debug("Debug mode", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        #define PI 3.141592
        #define HALFPI 1.5707

        sampler2D _MainTex;

        struct Input
        {
            float2 uv;
            float3 worldPos;
            float3 worldNormal;
        };

        float4 _Noises[50];
        int _WaveAmount;
        float _EchoMaxDistance;
        float _EchoWidth;
        float4 _EchoEmissionColor;
        float _debug;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            if (_debug == 0)
            {
                for (int i = 0; i < _Noises.Length; i++)
                {
                    float x = 1 - _Noises[i].w;
                    float distanceFade = max(0, cos(PI * x - HALFPI));

                    float halfWidth = _EchoWidth * 0.5;
                    float distance = length(IN.worldPos - _Noises[i].xyz) - _EchoMaxDistance * _Noises[i].w;
                    float range = 1 - (distance / halfWidth);

                    float minDistance = distance - halfWidth;
                    float maxDistance = distance + halfWidth;
                    float ringSize = (minDistance < 0 && maxDistance > 0);

                    float echoWave = ((sin(range * PI * _WaveAmount - 4.7)) + 1) * 0.5;

                    o.Emission += _EchoEmissionColor * (1 - echoWave) * ringSize * distanceFade;
                }
            }
            else
            {
                float4 color = float4(IN.worldNormal.xyz * 0.5,0);
                o.Emission =  color;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}