Shader "PostEffect/Black" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "" {}
	}

	HLSLINCLUDE
	
	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

	struct appdata_img {
		float4 vertex:POSITION;
		float2 texcoord:TEXCOORD0;
	};
	struct v2f {
		float4 pos : POSITION;
		float2 uv : TEXCOORD0;

		float4 uv01 : TEXCOORD1;
		float4 uv23 : TEXCOORD2;
		float4 uv45 : TEXCOORD3;
	};
	
	float4 offsets;
	
	sampler2D _MainTex;
	
	v2f vert (appdata_img v) {
		v2f o;
		VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
		o.pos = vertexInput.positionCS;
		o.uv.xy = v.texcoord.xy;

		return o;
	}
	
	half4 frag (v2f i) : COLOR {
		half4 color = tex2D(_MainTex, i.uv);
		
		color *= half4(0.8, 0.8, 0.8, 1);
		
		return color;
	}

	ENDHLSL
	
Subshader {
 Pass {
	  ZTest Always Cull Off ZWrite Off

      HLSLPROGRAM
      #pragma vertex vert
      #pragma fragment frag
      ENDHLSL
  }
}

}
