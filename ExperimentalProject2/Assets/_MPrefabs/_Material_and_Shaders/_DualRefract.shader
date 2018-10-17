Shader "Custom/Refract" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 1.0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;

		fixed4 DSwirl(sampler2D tex, inout float2 uv) {
		float radius = _ScreenParams.x;
		float2 center = float2(_ScreenParams.x, _ScreenParams.y*2);
		float2 texSize = float2(_ScreenParams.x/0.25	 , _ScreenParams.y /0.20);
		float2 tc = uv * texSize;
		tc -= center;
		float dist = length(tc);
		float angle = sin(_Time.y * 0.15);
		if (dist < radius)
		{
			float percent = (radius - dist) / radius;
			float theta = percent * percent * angle * 28.0;
			float s = sin(theta);
			float c = cos(theta);
			tc = float2(dot(tc, float2(c, -s)), dot(tc, float2(s, c)));

		}
		tc += center;
		
		 center = float2(_ScreenParams.x*3, _ScreenParams.y * 2);
		float2 texSize2 = float2(_ScreenParams.x / 0.25, _ScreenParams.y / .20);
		float2 tc2 = uv * texSize2;
		tc2 -= center;
		dist = length(tc2);
		angle = sin(_Time.y * 0.15);
		if (dist < radius)
		{
			float percent = (radius - dist) / radius;
			float theta = percent * percent * angle * 28.0;
			float s = sin(theta);
			float c = cos(theta);
			tc2 = float2(dot(tc2, float2(c, -s)), dot(tc2, float2(s, c)));

		}
		tc2 += center;
		
		float3 color = (tex2D(tex, tc / texSize) + tex2D(tex, tc2/texSize2)).rgb;
		//color.r = 1.0;
		return fixed4(color, 1.0);
	}

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed4 c = DSwirl(_MainTex, IN.uv_MainTex.xy) * _Color;
		
		o.Albedo = c.rgb;
		// Metallic and smoothness come from slider variables
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}