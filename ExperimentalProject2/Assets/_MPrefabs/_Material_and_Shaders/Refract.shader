// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

// Upgrade NOTE: replaced 'glstate.matrix.mvp' with 'UNITY_MATRIX_MVP'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
// Uses geometry normals to distort the image behind, and
// an additional texture to tint the color.

Shader "Custom/Refract" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
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

		fixed4 Swirl(sampler2D tex, inout float2 uv, float time) {
		float radius = _ScreenParams.x;
		float2 center = float2(_ScreenParams.x, _ScreenParams.y);
		float2 texSize = float2(_ScreenParams.x/0.5 , _ScreenParams.y /0.5);
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
		float3 color = tex2D(tex, tc / texSize).rgb;
		//color.r = 1.0;
		return fixed4(color, 1.0);
	}

	//CODE TAKEN FROM HERE: 
		//http://gamedev.stackexchange.com/questions/59797/glsl-shader-change-hue-saturation-brightness
		//https://www.youtube.com/watch?v=VKYUQnYhAH0&t
	float3 rgb2hsv(float3 c)
		{
			float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
			float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
			float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

			float d = q.x - min(q.w, q.y);
			float e = 1.0e-10;
			return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
		}

		float3 hsv2rgb(float3 c)
		{
			float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
			float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
			return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
		}

	void surf(Input IN, inout SurfaceOutputStandard o) {
		// Albedo comes from a texture tinted by color
		//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		fixed4 c = Swirl(_MainTex, IN.uv_MainTex.xy, 1) * _Color;
		float2 texSize = float2(_ScreenParams.x / 0.5, _ScreenParams.y / 0.5);
		float2 tc = IN.uv_MainTex.xy * texSize;
		float dist = length(tc);
		float3 cd = rgb2hsv(c.xyz);
		cd.x += dist * 2 + _Time.y * 2;
		c.xyz = hsv2rgb(cd);
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