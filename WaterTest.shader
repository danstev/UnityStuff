Shader "Custom/WaterTest" 
{
	Properties
	{
		//Input 
		//Main texture, it none, is white (0,0,0)
		_MainTex("Texture", 2D) = "white" {}
		//Displacement, uses red and green pixels so have red and green image.
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		//How much displacement happens
		_Magnitude("Magnitude", Range(0,0.1)) = 1
		//Transparency
		_Alpha("Alpha", Range(0,1)) = 1
	}
	SubShader
	{
		
		Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }

		Pass
		{
			// No culling or depth
			Cull Off
			//ZWrite Off 
			//ZTest Always
			
			//Blend mode
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				//What we get fromrenderer.
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			
			struct v2f
			{
				//vertex to fragment data
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				//turn date from appdata to vertex
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			//Get input
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Magnitude;
			float _Alpha;

			float4 frag (v2f i) : SV_Target
			{
				//get distortion uv from fragment shader
				float2 distuv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);
				
				//get displacement, apply to pixel
				float2 disp = tex2D(_DisplaceTex, distuv).xy;
				disp = ((disp * 2) - 1) * _Magnitude;
				
				//apply displacement to the main texture
				float4 col = tex2D(_MainTex, i.uv + disp);
				//add transparency
				col.a = _Alpha;
				//send back pixel
				return col;
			}
			ENDCG
		}
	}
}
