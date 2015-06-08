Shader "_Shaders/Blink"
{
	Properties {
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Color", Color) = (0, 0, 0, 1)
		_BlinkColor ("_BlinkColor", Color) = (1, 1, 1, 1);
	}
	
	SubShader {
		Tags { 
			"RenderType"="Opaque" 
			"Queue"="Transparent+1"			
		}
		Blend SrcAlpha OneMinusSrcAlpha
		Zwrite off
		
		Pass {
			CGPROGRAM
			//#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON

			sampler2D _MainTex;
			fixed4 _Color;
			fixed4 _BlinkColor;
			
			struct Vertex {
				float4 vertex : POSITION;
				float2 uv_MainTex : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};		
			
			struct Fragment {
				float4 vertex : POSITION;
				float2 uv_MainTex : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};
			
			Fragment vert (Vertex v) {
				Fragment f;
				f.vertex = mul (UNITY_MATRIX_MVP, v.vertex);
				f.uv_MainTex = v._uv_MainTex;
				f.uv2 = v.uv2;
				
				return f;
			}
			
			float4 frag (Fragment f) : COLOR {
				fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
				c.rgb = lerp (c.rgb, _BlinkColor.rgb, _BlinkColor.a);
				float4 o = c.rgb;
				return o;
			}
								
			ENDCG
		}
	} 
	FallBack "Diffuse"
}