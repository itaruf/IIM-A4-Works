Shader "IIM/ImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Power("Power", Range(-0.5, 0.5)) = 0
        _Angle("Angle", Range(0.0, 360)) = 180
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Power;
            float _Angle;

            fixed4 frag(v2f i) : SV_Target
            {
               float2 uvDisplacement = float2(cos(_Angle) * _Power, sin(_Angle) * _Power);

                fixed4 col = tex2D(_MainTex, i.uv);

                col.r = tex2D(_MainTex, i.uv - uvDisplacement);
                col.g = tex2D(_MainTex, i.uv);
                col.b = tex2D(_MainTex, i.uv + uvDisplacement);

                return col;
            }
            ENDCG
        }
    }
}
