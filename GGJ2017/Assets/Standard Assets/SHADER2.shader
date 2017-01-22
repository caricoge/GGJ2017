Shader "Custom/Intersection"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _IntersectColor("Intersection Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        ZWrite off
 
        CGPROGRAM
        #pragma surface surf Unlit alpha
        #pragma multi_compile_fog
        #include "UnityCG.cginc"
       
        struct Input
        {
            float3 viewDir;
            float4 screenPos;
        };
 
        uniform sampler2D _CameraDepthTexture;
        float4 _Color;
        float4 _IntersectColor;
           
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
 
            // Intersection detection
            float sceneZ = LinearEyeDepth(tex2Dproj(_CameraDepthTexture,
            UNITY_PROJ_COORD(IN.screenPos)).r);
            float partZ = IN.screenPos.z;
            float diff = (abs(sceneZ - partZ));
 
            if (diff <= 1)
            {
                o.Albedo = lerp(_IntersectColor, _Color, float4(diff, diff, diff, diff));
            }
        }
 
        fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            fixed4 c;
            c.rgb = s.Albedo;
            c.a = s.Alpha;
            return c;
        }
 
        ENDCG
    }
}