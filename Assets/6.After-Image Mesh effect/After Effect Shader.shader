Shader "FX/After Image Effect HLSL" 
{
    Properties
    {
        _Color("Extra Color", Color) = (1,1,1,1)		
        _RimColor("Rim Color", Color) = (0,1,1,1)
        _MainTex("Main Texture", 2D) = "black" {}
        _RimPower("Rim Power", Range(1,50)) = 20
        [PerRendererData]_Fade("Fade Amount", Range(0,1)) = 1
        _Grow("Grow", Range(0,1)) = 0.05
    }

    SubShader
    {
        Tags {  "Queue" = "Transparent""RenderType"="Transparent" "RenderPipeline"="UniversalRenderPipeline"}
        Blend SrcAlpha One 
        Zwrite Off
        Cull Back 
        Pass
        {
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                float3 normal       : NORMAL;
            };

            struct Varyings
            {
                float2 uv           : TEXCOORD0;
                float4 positionHCS  : SV_POSITION;
                float3 wpos         : TEXCOORD1; // worldposition
                float3 normalDir    : TEXCOORD2; // normal direction for rimlighting
            };

            
            
            
            
            
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            
            CBUFFER_START(UnityPerMaterial)
            float4 _RimColor;
            float _RimPower;
            float4 _MainTex_ST;
            float _Fade;
            float4 _Color;
            float _Grow;
            CBUFFER_END
            

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                // grow based on normals and fade property
                IN.positionOS.xyz += IN.normal * saturate(1-  _Fade) * _Grow;
                
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);

                
                
                // world position and normal direction for fresnel
                OUT.wpos = mul(unity_ObjectToWorld, IN.positionOS).xyz;
                OUT.normalDir = normalize(mul(float4(IN.normal, 0.0), unity_WorldToObject).xyz);		
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float4 text = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                // rim lighting
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - IN.wpos.xyz);
                // fresnel based on view and normal
                half rim = 1.0 - saturate(dot(viewDirection, IN.normalDir));
                rim = pow(rim, _RimPower);									
                
                // end result color 	
                float4 col = (text * _Color) +(rim * _RimColor);			
                col.a *=   _Color.a;
                col.a *= (text.r + text.g + text.b) * 0.33f;
                col.a += rim;

                // quick smoothstep to make the fade more interesting
                col.a = smoothstep( col.a ,col.a + 0.05 ,_Fade);					
                col = saturate(col);


                return col;
            }
            ENDHLSL
        }
    }
}