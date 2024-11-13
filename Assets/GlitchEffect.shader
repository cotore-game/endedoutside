Shader "Custom/GlitchEffect"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Intensity("Glitch Intensity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Intensity;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float glitchAmount = frac(sin(i.uv.y * _Intensity + _Time.y * 50.0) * 43758.5453);
                float2 glitchOffset = float2(glitchAmount * 0.05, 0); // 横方向のズレ
                fixed4 color = tex2D(_MainTex, i.uv + glitchOffset);

                // ランダムな色シフト
                color.r += sin(_Time.y * 10.0 + i.uv.x * 20.0) * _Intensity * 0.2;
                color.g += cos(_Time.y * 15.0 + i.uv.y * 25.0) * _Intensity * 0.2;

                return color;
            }
            ENDCG
        }
    }
}